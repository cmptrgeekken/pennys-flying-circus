using EveMarket.Core.Enums;
using EveMarket.Core.Models;
using EveMarket.Core.Models.CrestApi;
using EveMarket.Core.Repositories;
using eZet.EveLib.EveCentralModule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using EveMarket.Core.Repositories.Db;

namespace EveMarket.Core.Services
{
    public class ItemService
    {

        private readonly EveDb _eveDb;
        private readonly EveCentral _eveCentral;
        private readonly EveMarketDataEntities _marketEntities;
        private static readonly MemoryCache Cache;

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


        static ItemService()
        {
            Cache = MemoryCache.Default;
        }

        public ItemService(EveDb eveDb, EveCentral eveCentral, EveMarketDataEntities marketEntities)
        {
            _eveDb = eveDb;
            _eveCentral = eveCentral;
            _marketEntities = marketEntities;
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

        public MineralQuote SaveQuote(MineralList mineralList, decimal subtotal, decimal shipping, decimal total)
        {
            var mineralQuote = new MineralQuote
            {
                //QuoteLookup = GenerateQuoteLookup(),
                TritaniumQty = (int)mineralList.Tritanium,
                PyeriteQty = (int)mineralList.Pyerite,
                MegacyteQty = (int)mineralList.Megacyte,
                NocxiumQty = (int)mineralList.Nocxium,
                IsogenQty = (int)mineralList.Isogen,
                MexallonQty = (int)mineralList.Mexallon,
                ZydrineQty = (int)mineralList.Zydrine,
                MorphiteQty = (int)mineralList.Morphite,
                Subtotal = subtotal,
                Shipping = shipping,
                Total = total,
                SubmissionDate = DateTime.Now,
            };

            _marketEntities.MineralQuotes.Add(mineralQuote);
            _marketEntities.SaveChanges();

            return mineralQuote;
        }

        public string GenerateQuoteLookup()
        {
            var values = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Split(new[] {""}, StringSplitOptions.RemoveEmptyEntries);
            const int quoteLookupLength = 5;

            var rand = new Random();
            while(true)
            {
                var quoteLookup = new string(Enumerable.Repeat(values, quoteLookupLength).SelectMany(s => s[rand.Next(0,s.Length)]).ToArray());

                if (!_marketEntities.MineralQuotes.Any(q => q.QuoteLookup == quoteLookup))
                {
                    return quoteLookup;
                }
            }
        }

        public OrderSummary GetOrderSummary(IEnumerable<OreMinerals> ores, List<Mineral> minerals, MineralList mineralList)
        {
            var oreList = ores.ToList();

            var perfectPurchasePrice = oreList.Sum(o => Math.Round((decimal)o.Pricing.CalculateBestTotal((int)Math.Ceiling(o.Qty)), 2));
            var buyAllPurchasePrice = oreList.Sum(o => o.TotalPrice);
            var mineralBuyAllPurchasePrice = minerals.Sum(m => m.TotalPrice);
            var totalOreVolume = (decimal)oreList.Sum(o => o.Qty*o.Volume);
            var totalMineralVolume = minerals.Sum(m => m.Volume*m.DesiredQty);
            // TODO: Make shipping cost configurable
            var sourceStagingShippingCost = totalOreVolume*300 + perfectPurchasePrice*.02m;
            var stagingRefineryShippingCost = 0;//totalOreVolume*100;
            var refiningCost = 0;//totalOreVolume*10;
            var refineryStationShippingCost = 0;//totalMineralVolume*5;
            // TODO: Make desired profit configurable
            var profitSell = buyAllPurchasePrice*1.0m;

            var predictedSell = profitSell + sourceStagingShippingCost;
            var predictedProfit = predictedSell - buyAllPurchasePrice - sourceStagingShippingCost;

            var mineralValueRatio = predictedSell/mineralBuyAllPurchasePrice;

            foreach (var mineral in minerals)
            {
                if (mineral.Qty == 0) continue;
                mineral.ComparisonTotal = Math.Round(mineral.TotalPrice*mineralValueRatio, 2);
                mineral.ComparisonPrice = Math.Round(mineral.ComparisonTotal/(decimal)mineral.DesiredQty, 2);
            }

            return new OrderSummary
            {
                Ores = oreList,
                Minerals = minerals,
                //MineralQuote = SaveQuote(mineralList, profitSell, sourceStagingShippingCost, predictedSell),
                MineralValueRatio = mineralValueRatio,
                PurchaseCostBest = perfectPurchasePrice,
                PurchaseCost = buyAllPurchasePrice,
                TotalOreVolume = totalOreVolume,
                TotalMineralVolume = totalMineralVolume,
                SourceStagingShippingCost = sourceStagingShippingCost,
                StagingRefineryShippingCost = stagingRefineryShippingCost,
                RefiningCost = refiningCost,
                RefineryStationShippingCost = refineryStationShippingCost,
                ProfitSell = profitSell,
                PredictedSell = predictedSell,
                PredictedProfit = predictedProfit,
            };
        }

        public ItemPricing GetCurrentItemPricing(long typeId, long regionId = 10000002, IEnumerable<long> stationIds = null)
        {

            var cacheKey = $"CurrentItemPricing-{typeId}";

            if (Cache.Contains(cacheKey))
            {
                return Cache[cacheKey] as ItemPricing;
            }

            var crestUrl = $"https://crest-tq.eveonline.com/market/{regionId}/orders/sell/?type=https://crest-tq.eveonline.com/inventory/types/{typeId}/";

            ItemMarketOrders result;

            using (var client = new WebClient())
            {
                var content = client.DownloadString(crestUrl);
                result = JsonConvert.DeserializeObject<ItemMarketOrders>(content);
            }

            if (result != null)
            {
                var itemPricing = new ItemPricing
                {
                    RegionId = regionId,
                    MarketOrders = result.Items.OrderBy(i => i.Price),
                    // TODO Make station ID configurable
                    AllowedStationIds = new List<long> { 60003760 },
                };
                Cache.Add(cacheKey, itemPricing, new DateTimeOffset(DateTime.Now.AddMinutes(5)));

                return itemPricing;
            }
            
            return null;
        }
    }
}
