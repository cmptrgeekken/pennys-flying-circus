using EveMarket.Core.Enums;
using EveMarket.Core.Models;
using EveMarket.Core.Models.CrestApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using eZet.EveLib.EveCrestModule;
using EveMarket.Core.Models.FlyingCircus;
using EveMarket.Core.Repositories.Eve;
using EveMarket.Core.Services.Interfaces;
using LiteDB;

namespace EveMarket.Core.Services
{
    public class ItemService : IItemService
    {

        private readonly EveDb _eveDb;
        private readonly LiteDatabase _liteDb;

        private static readonly Dictionary<MineralType, ReprocessingType> MineralPrimaryOreMapping 
            = new Dictionary<MineralType, ReprocessingType>
        {
            {MineralType.Tritanium, ReprocessingType.Veldspar},
            {MineralType.Pyerite, ReprocessingType.Scordite},
            {MineralType.Mexallon, ReprocessingType.Plagioclase},
            {MineralType.Isogen, ReprocessingType.Kernite},
            {MineralType.Nocxium, ReprocessingType.Pyroxeres},
            {MineralType.Zydrine, ReprocessingType.Bistot},
            {MineralType.Megacyte, ReprocessingType.Arkonor},
            {MineralType.Morphite, ReprocessingType.Mercoxit}
        };

        private static readonly Dictionary<MineralType, int> MineralSortOrder
            = new Dictionary<MineralType, int>
            {
                {MineralType.Tritanium, 8},
                {MineralType.Pyerite, 7},
                {MineralType.Mexallon, 6},
                {MineralType.Isogen, 5},
                {MineralType.Nocxium, 4},
                {MineralType.Zydrine, 2},
                {MineralType.Megacyte, 3},
                {MineralType.Morphite, 1},
            };

        public ItemService(EveDb eveDb, LiteDatabase liteDb)
        {
            _eveDb = eveDb;
            _liteDb = liteDb;
        }

        public List<OreGroup> GetOreGroups(ReprocessingSkills reprocessingSkills)
        {
            var oreCategory = _eveDb.invCategories.Single(c => c.categoryName == "Asteroid" && true == c.published);

            var oreGroups = oreCategory.invGroups.Where(g => g.groupName != "Ice" && true == g.published)
                .Select(g => new OreGroup
                {
                    ReprocessingType = (ReprocessingType)
                                    Enum.Parse(typeof(ReprocessingType), g.groupName.Replace(" ", ""), true),
                    GroupName = g.groupName,
                    Ores = g.invTypes.Where(t => true == t.published && t.portionSize == 1 && t.marketGroupID > 0)
                        .OrderBy(t => t.basePrice)
                        .Select((t, i) =>
                        {
                            var yieldBonus = i*.05;
                            var reprocessingType =
                                (ReprocessingType)
                                    Enum.Parse(typeof(ReprocessingType), g.groupName.Replace(" ", ""), true);
                            return new OreMinerals
                            {
                                Id = t.typeID,
                                Name = t.typeName,
                                ReprocessingType = reprocessingType,
                                ReprocessingRate = reprocessingSkills.CalculateReprocessingRate(reprocessingType),
                                YieldModifier = yieldBonus,
                                Volume = t.volume,
                                Pricing = GetCurrentItemPricing(t.typeID),
                                ReprocessedMinerals = new MineralList
                                {
                                    Tritanium = t[MineralType.Tritanium],
                                    Pyerite = t[MineralType.Pyerite],
                                    Mexallon = t[MineralType.Mexallon],
                                    Isogen = t[MineralType.Isogen],
                                    Nocxium = t[MineralType.Nocxium],
                                    Zydrine = t[MineralType.Zydrine],
                                    Megacyte = t[MineralType.Megacyte],
                                    Morphite = t[MineralType.Morphite],
                                }
                            };
                        }).ToList()
                });

            return oreGroups.ToList();
        }

        public List<Mineral> GetMinerals()
        {
            return _eveDb.invGroups.Where(g => g.groupName == "Mineral")
                .SelectMany(g => g.invTypes)
                .Where(t => true == t.published)
                .ToList()
                .Select(t =>
                {
                    var mineralType = (MineralType) Enum.Parse(typeof(MineralType), t.typeName);

                    return new Mineral
                    {
                        Id = t.typeID,
                        Name = t.typeName,
                        Volume = t.volume,
                        MineralType = mineralType,
                        PrimaryOreReprocessingType = MineralPrimaryOreMapping[mineralType],
                        ReprocessingOrder = MineralSortOrder[mineralType],
                        Pricing = GetCurrentItemPricing(t.typeID)
                    };
                }).ToList();
        }

        public OrderSummary GetCompressedOres(ReprocessingSkills reprocessingSkills, MineralList mineralList)
        {
            var oreGroups = GetOreGroups(reprocessingSkills);
            var minerals = GetMinerals();

            var optimizedOres = OptimizeOres(minerals, oreGroups, mineralList, reprocessingSkills);

            var finalOres = optimizedOres.Where(o => o.Qty > 0).ToList();

            var currentMinerals = new MineralList();
            foreach (var ore in finalOres)
            {
                foreach (MineralType mineral in Enum.GetValues(typeof(MineralType)))
                {
                    currentMinerals[mineral] += ore.GetMineralQty(mineral, reprocessingSkills.CalculateReprocessingRate(ore.ReprocessingType));
                }
            }

            var generatedMinerals = new List<Mineral>();
            foreach (var mineral in minerals)
            {
                mineral.Qty = currentMinerals[mineral.MineralType];
                mineral.DesiredQty = mineralList[mineral.MineralType];

                generatedMinerals.Add(mineral);
            }

            return GetOrderSummary(finalOres, generatedMinerals, mineralList);
        }

        protected List<OreMinerals> OptimizeOres(List<Mineral> minerals, List<OreGroup> oreGroups, MineralList mineralList, ReprocessingSkills reprocessingSkills)
        {
            foreach (var mineral in minerals.OrderBy(o => o.ReprocessingOrder))
            {
                var mineralType = mineral.MineralType;
                var primaryOreGroup = oreGroups.Single(o => o.ReprocessingType == mineral.PrimaryOreReprocessingType);

                var desiredMineralQty = mineralList[mineralType];

                foreach (var ore in oreGroups.SelectMany(o => o.Ores).Where(o => o.Qty > 0))
                {
                    desiredMineralQty -= ore.GetMineralQty(mineralType, ore.ReprocessingRate);
                }

                foreach (var order in primaryOreGroup.OptimizedMarketOrders)
                {
                    if (desiredMineralQty <= 0) break;

                    var oreMineralYield = order.AssociatedOre.ReprocessedMinerals[mineralType]*
                                          order.AssociatedOre.ReprocessingRate;

                    var desiredOrderQty = Math.Ceiling(Math.Min(order.Volume, desiredMineralQty/oreMineralYield));

                    desiredMineralQty -= desiredOrderQty*oreMineralYield;
                    primaryOreGroup.Ores.Single(o => o.Id == order.AssociatedOre.Id).Qty += desiredOrderQty;
                }
            }

            return oreGroups.SelectMany(og => og.Ores.Where(o => o.Qty > 0)).ToList();
        }
        
        public OrderSummary GetOrderSummary(IEnumerable<MarketItem> items, List<Mineral> minerals, MineralList mineralList)
        {
            var itemList = items.ToList();

            var perfectPurchasePrice = itemList.Sum(o => Math.Round(o.Pricing.CalculateBestTotal((int)Math.Ceiling(o.Qty)), 2));
            var buyAllPurchasePrice = itemList.Sum(o => o.TotalPrice);

            var totalOreVolume = (decimal) itemList.Sum(o => o.Volume*o.Qty);
            var sourceStagingShippingCost = itemList.Sum(o => o.AverageShippingCost*(decimal) o.Qty);

            var mineralBuyAllPurchasePrice = minerals?.Sum(m => m.TotalPrice);
            var totalMineralVolume = minerals?.Sum(m => m.Volume * m.DesiredQty);
            var mineralValueRatio = (buyAllPurchasePrice + sourceStagingShippingCost) / mineralBuyAllPurchasePrice;

            if (minerals != null)
            {
                foreach (var mineral in minerals)
                {
                    if (mineral.Qty == 0) continue;
                    mineral.ComparisonTotal = Math.Round(mineral.TotalPrice * mineralValueRatio.Value, 2);
                    mineral.ComparisonPrice = Math.Round(mineral.ComparisonTotal / (decimal)mineral.DesiredQty, 2);
                }
            }

            return new OrderSummary
            {
                MarketItems = itemList,
                Minerals = minerals,
                MineralValueRatio = mineralValueRatio,
                TotalMineralVolume = totalMineralVolume,
                PurchaseCostBest = perfectPurchasePrice,
                PurchaseCost = buyAllPurchasePrice,
                TotalVolume = totalOreVolume,
                SourceStagingShippingCost = sourceStagingShippingCost,
            };
        }

        public invType GetItem(string itemName)
        {
            return _eveDb.invTypes.SingleOrDefault(i => i.typeName == itemName);
        }

        public invType GetItem(long itemId)
        {
            return _eveDb.invTypes.SingleOrDefault(i => i.typeID == itemId);
        }

        public IEnumerable<Blueprint> GetBlueprints(string name)
        {
            name = name.ToLowerInvariant();
            var matchedTypes = _eveDb.industryActivityProducts.Where(t =>
                true == t.type.published
                && true == t.productType.published
                && t.productType.typeName.ToLower().StartsWith(name)
                && t.productType.invGroup.invCategory.categoryName != "Blueprint")
                .OrderBy(t => t.productType.typeName);

            return matchedTypes.ToList().Select(bp => new Blueprint
            {
                TypeId = bp.productTypeID,
                TypeName = bp.productType.typeName,
            });
        }

        public Blueprint GetBlueprint(int typeId, IndustryActivityType activityType)
        {
            var bp = _eveDb.industryActivityProducts.SingleOrDefault(p => p.productTypeID == typeId && p.activityID == (int)activityType);

            return bp == null
                ? null
                : new Blueprint
                {
                    TypeId = bp.productTypeID,
                    TypeName = bp.productType.typeName,
                    Skills =
                        bp.type.typeSkills.Where(a => a.activityID == (int) IndustryActivityType.Manufacturing)
                            .ToList()
                            .Select(s => new BlueprintSkill
                            {
                                SkillId = s.skillID,
                                SkillName = s.skillType.typeName,
                                MinimumLevel = s.level,
                            }),
                    Materials = GetMaterials(bp.type),
                };
        }

        protected IEnumerable<BlueprintMaterial> GetMaterials(invType type)
        {
            if (type == null)
            {
                return new List<BlueprintMaterial>();
            }

            return type.industryActivityMaterials.Where(am => am.activityID == (int)IndustryActivityType.Manufacturing)
                .ToList()
                .Select(m => new BlueprintMaterial()
                {
                    TypeId = m.materialTypeID,
                    TypeName = m.materialType.typeName,
                    Qty = m.quantity,
                    Volume =m.materialType.volume,
                    Skills = m.type.typeSkills.Where(a => a.activityID == (int)IndustryActivityType.Manufacturing).ToList().Select(s => new BlueprintSkill
                    {
                        SkillId = s.skillID,
                        SkillName = s.skillType.typeName,
                        MinimumLevel = s.level,
                    }),
                    Materials = GetMaterials(m.materialType.activityProducts.Where(p => p.activityID == (int)IndustryActivityType.Manufacturing).Select(p => p.type).SingleOrDefault())
                });
        }

        public IEnumerable<mapSolarSystem> GetSystems(string prefix)
        {
            prefix = prefix.ToLowerInvariant();
            var systems = _eveDb.mapSolarSystems.Where(s => s.solarSystemName.ToLower().StartsWith(prefix));

            return systems.ToList();
        }

        public IEnumerable<staStation> GetStations(int systemId, string prefix)
        {
            prefix = prefix.ToLowerInvariant();
            var stations =
                _eveDb.staStations.Where(s => s.solarSystemID == systemId && s.stationName.ToLower().StartsWith(prefix));

            return stations.ToList();
        }

        public OrderSummary GetItemPricing(List<ItemLookup> itemList, decimal iskPerM3, decimal collateralPct, long stationId)
        {
            var station = _eveDb.staStations.Single(s => s.stationID == stationId);
            var regionId = station.regionID.Value;

            var items = itemList
                .Select(il => _eveDb.invTypes.SingleOrDefault(i => i.typeID == il.TypeId))
                .Where(i => i != null)
                .Select(i => new MarketItem()
                {
                    Id = i.typeID,
                    Name = i.typeName,
                    Volume = i.volume,
                    Pricing = GetCurrentItemPricing(i.typeID, regionId, new List<long> {stationId}),
                    CollateralPct = collateralPct,
                    IskPerM3 = iskPerM3,
                    Qty = itemList.First(il => il.TypeId == i.typeID).Qty,
                });
            
            return GetOrderSummary(items, null, null);
        }

        public ItemPricing GetCurrentItemPricing(long typeId, long regionId = 10000002, IEnumerable<long> stationIds = null)
        {
            var region = _eveDb.mapRegions.Single(r => r.regionID == regionId);
            var regionStations = region.stations.ToList();
            var stationDict = regionStations.ToDictionary(s => s.stationID, s => s.stationName);

            var sellOrders = _liteDb.GetCollection<RegionMarketOrder>("region-market-orders");

            var regionOrders = sellOrders.FindOne(o => o.TypeId == typeId && o.RegionId == regionId);

            if (regionOrders != null)
            {
                foreach (var marketOrder in regionOrders.MarketOrders)
                {
                    marketOrder.StationName = stationDict[marketOrder.StationId];
                }

                var itemPricing = new ItemPricing
                {
                    RegionId = regionId,
                    LastUpdated = regionOrders.LastUpdated,
                    MarketOrders = regionOrders.MarketOrders,
                    AllowedStationIds = stationIds ?? new List<long> { 60003760 },
                };

                return itemPricing;
            }
            
            return null;
        }

        public void RefreshMarketOrders(long regionId)
        {
            var crestUrl = $"https://crest-tq.eveonline.com/market/{regionId}/orders/all/?page={{0}}";

            var marketOrders = new List<CrestMarketOrder>();
            var currentPage = 1;


            CrestMarketOrderList result;
            do
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(string.Format(crestUrl, currentPage));
                webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                using (var response = webRequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var content = reader.ReadToEnd();
                    result = JsonConvert.DeserializeObject<CrestMarketOrderList>(content);

                    marketOrders.AddRange(result.Items);
                }
            } while (currentPage++ < result.PageCount);

            var sellOrders = marketOrders.Where(o => !o.Buy)
                .OrderBy(o => o.Price)
                .GroupBy(o => o.Type)
                .Select(o => new RegionMarketOrder
                {
                    TypeId = o.Key,
                    RegionId = regionId,
                    LastUpdated = DateTime.UtcNow,
                    MarketOrders = o.Select(i => new MarketOrder
                    {
                        Price = i.Price,
                        StationId = i.StationId,
                        TypeId = i.Type,
                        Volume = i.Volume,
                    })
                });
            using (var trans = _liteDb.BeginTrans())
            {
                var orders = _liteDb.GetCollection<RegionMarketOrder>("region-market-orders");

                orders.EnsureIndex(i => i.RegionId);
                orders.EnsureIndex(i => i.TypeId);

                orders.Delete(o => o.RegionId == regionId);
                orders.Insert(sellOrders);

                trans.Commit();
            }
        }
    }
}
