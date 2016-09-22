using System;
using System.Collections.Generic;
using System.Dynamic;
using EveMarket.Core.Models;
using EveMarket.Web.Models;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using eZet.EveLib.EveAuthModule;
using EveMarket.Core.Enums;
using EveMarket.Core.Extensions;
using EveMarket.Core.Repositories.Eve;
using EveMarket.Core.Services;
using EveMarket.Core.Services.Interfaces;

namespace EveMarket.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IPlayerService _playerService;
        private IEveService _eveService;

        public CalculatorController(IPlayerService playerService, IItemService itemService)
        {
            _playerService = playerService;
            _itemService = itemService;
        }


        // GET: Ore
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSystems(string prefix)
        {
            var systems = _itemService.GetSystems(prefix);

            var viewModel = systems.Select(s => new
            {
                SystemId = s.solarSystemID,
                SystemName = s.solarSystemName
            });

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStations(int systemId, string prefix)
        {
            var stations = _itemService.GetStations(systemId, prefix);

            var viewModel = stations.Select(s => new
            {
                StationId = s.stationID,
                StationName = s.stationName,
            });

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBlueprints(string prefix)
        {
            var bps = _itemService.GetBlueprints(prefix);
            
            return Json(bps, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBlueprintDetails(int typeId)
        {
            var details = _itemService.GetBlueprint(typeId, IndustryActivityType.Manufacturing);

            return Json(details, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BlueprintCalculator()
        {
            return View((OreListModel)null);
        }


        public async Task<ActionResult> FittingsSelector()
        {
            _eveService = new EveService(Session["RefreshToken"] as string);

            var fittings = await _eveService.GetFittings();

            return View(fittings);
        }


        [HttpGet]
        public ActionResult OreCalculator(MineralList desiredMinerals, IEnumerable<ItemLookupViewModel> itemList)
        {
            var skills = _playerService.GetReprocessingSkills();

            var viewModel = new OreListModel
            {
                Skills = skills,
                DesiredMinerals = desiredMinerals,
            };

            if (desiredMinerals.TotalVolume > 0)
            {
                viewModel.OreOrderSummary = _itemService.GetCompressedOres(skills, desiredMinerals);
            }

            return View(viewModel);
        }

        public ActionResult GetBlueprintSummary(BlueprintCalculationViewModel viewModel)
        {

            var bpLookup = new Dictionary<long, Dictionary<long, BlueprintLookupViewModel>>();
            var materialLookup = new Dictionary<long, Dictionary<long, ItemLookupViewModel>>();

            var blueprintList = new Dictionary<long, BlueprintLookupViewModel>();
            var materialList = new Dictionary<long, ItemLookupViewModel>();

            foreach (var blueprint in viewModel.Blueprints)
            {
                if (blueprint.Qty <= 0) continue;

                var bpMaterialList = new Dictionary<long, ItemLookupViewModel>();
                var bpBlueprintList = new Dictionary<long, BlueprintLookupViewModel>();

                GatherBlueprintMaterials(blueprint, viewModel.MfgSystemCostIndex, bpMaterialList, bpBlueprintList);
                
                foreach (var kvp in bpMaterialList)
                {
                    if (!materialList.ContainsKey(kvp.Key))
                    {
                        materialList.Add(kvp.Key, kvp.Value);
                    }
                    else
                    {
                        materialList[kvp.Key].Qty += kvp.Value.Qty;
                    }
                }

                foreach (var kvp in bpBlueprintList)
                {
                    if (!blueprintList.ContainsKey(kvp.Key))
                    {
                        blueprintList.Add(kvp.Key, kvp.Value);
                    }
                    else
                    {
                        blueprintList[kvp.Key].Qty += kvp.Value.Qty;
                    }
                }

                bpLookup.Add(blueprint.TypeId, bpBlueprintList);
                materialLookup.Add(blueprint.TypeId, bpMaterialList);
            }

            var mineralList = new MineralList();
            var mineralNames = mineralList.GetMineralNames().ToList();
            var itemList = new List<ItemLookup>();
            foreach (var material in materialList.Values)
            {
                var item = _itemService.GetItem(material.TypeId);
                if (viewModel.CompressMinerals && mineralNames.Contains(item.typeName))
                {
                    mineralList[item.typeName] += material.Qty;
                }
                else
                {
                    itemList.Add(new ItemLookup
                    {
                        TypeId = material.TypeId,
                        Qty = material.Qty,
                    });
                }
            }

            foreach (var bpc in blueprintList.Values)
            {
                var item = _itemService.GetItem(bpc.TypeId);
                bpc.Name = item.typeName;
            }

            var reprocessingSkills = _playerService.GetReprocessingSkills();
            var compressedOreSummary = _itemService.GetCompressedOres(reprocessingSkills, mineralList);
            var orderSummary = _itemService.GetItemPricing(itemList, 300, .02m, viewModel.PurchaseStationId);

            var blueprintSummary = new BlueprintCalculationResultsViewModel
            {
                OrderSummary = orderSummary,
                OreSummary = compressedOreSummary,
                BpcResults = new BpcResultsViewModel
                {
                    Blueprints = blueprintList.Values.ToList()
                },
            };

            foreach (var bp in viewModel.Blueprints)
            {
                var blueprintCostAnalysis = new BlueprintCalculationResultViewModel();

                var matList = materialLookup[bp.TypeId];
                var bpList = bpLookup[bp.TypeId];

                var item = _itemService.GetItem(bp.TypeId);
                blueprintCostAnalysis.TypeId = bp.TypeId;
                blueprintCostAnalysis.TypeName = item.typeName;
                blueprintCostAnalysis.Qty = bp.Qty;

                foreach (var mineral in compressedOreSummary.Minerals)
                {
                    if (matList.ContainsKey(mineral.Id))
                    {
                        blueprintCostAnalysis.MaterialPrice += matList[mineral.Id].Qty*mineral.ComparisonPrice;
                    }
                }

                foreach (var material in orderSummary.MarketItems)
                {
                    if (matList.ContainsKey(material.Id))
                    {
                        blueprintCostAnalysis.MaterialPrice += matList[material.Id].Qty*(material.AveragePrice + material.AverageShippingCost);
                    }
                }

                foreach (var bpEntry in bpList.Values)
                {
                    blueprintCostAnalysis.BlueprintPrice += (decimal)(bpEntry.Qty*bpEntry.JobCost);
                }

                blueprintCostAnalysis.TotalPrice = blueprintCostAnalysis.BlueprintPrice
                                                   + blueprintCostAnalysis.MaterialPrice
                                                   + bp.BpcPackCost;

                blueprintSummary.BlueprintResults.Add(blueprintCostAnalysis);
            }



            return PartialView(blueprintSummary);
        }

        private void GatherBlueprintMaterials(BlueprintMaterialViewModel material, double mfgSystemCostIndex, Dictionary<long, ItemLookupViewModel> materialList, Dictionary<long, BlueprintLookupViewModel> blueprintList)
        {
            if (material.BuildComponents && material.Materials.Any())
            {
                if (!blueprintList.ContainsKey(material.TypeId))
                {
                    blueprintList.Add(material.TypeId, new BlueprintLookupViewModel
                    {
                        TypeId = material.TypeId,
                        JobCost = material.JobBaseCost * mfgSystemCostIndex
                    });

                    blueprintList[material.TypeId].Qty += material.Qty;
                }

                foreach (var subMaterial in material.Materials)
                {
                    GatherBlueprintMaterials(subMaterial, mfgSystemCostIndex, materialList, blueprintList);;
                }
            }
            else
            {
                if (!materialList.ContainsKey(material.TypeId))
                {
                    materialList.Add(material.TypeId, new ItemLookupViewModel
                    {
                        TypeId = material.TypeId
                    });
                }

                materialList[material.TypeId].Qty += material.Qty;
            }

        }

        [HttpPost]
        public ActionResult ParseItems(string textInput, bool useCompressedOres = false, bool buildShips = false, int multiplier = 1)
        {
            var inputTests = new []
            {
                new Regex(@"^\[(?<itemName>[^,]+),"),
                new Regex(@"^(?<itemName>[^\t]+)\t(?<itemQty>[\d,]+)$"),
                new Regex(@"^(?<itemQty>[\d,]+)x?\s+(?<itemName>[^\t]+)"),
                new Regex(@"^(?<itemName>.+?)(\sx(?<itemQty>[\d,]+))?$"),
                new Regex(@"^(?<itemName>[^\d\t]+)"),
            };

            var lines = textInput.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);

            var mineralList = new MineralList();
            var itemList = new List<ItemLookup>();
            var invalidLines = new List<string>();
            var mineralNames = mineralList.GetMineralNames().ToList();

            foreach (var line in lines)
            {
                var matchFound = false;
                foreach (var inputTest in inputTests)
                {
                    var inputMatch = inputTest.Match(line.Trim());
                    if (inputMatch.Success)
                    {
                        var itemQty = inputMatch.Groups["itemQty"];
                        var itemName = inputMatch.Groups["itemName"].Value;
                        var qty = multiplier * (itemQty.Success ? int.Parse(itemQty.Value.Replace(",", "")) : 1);

                        if (useCompressedOres && mineralNames.Contains(itemName))
                        {
                            mineralList[itemName] += qty;
                            matchFound = true;
                        }
                        else
                        {
                            var item = _itemService.GetItem(itemName);
                            
                            if (item != null)
                            {
                                var itemEntry = itemList.FirstOrDefault(il => il.TypeId == item.typeID);
                                if (itemEntry == null)
                                {
                                    itemList.Add(new ItemLookup
                                    {
                                        TypeId = item.typeID,
                                        Qty = qty
                                    });
                                }
                                else
                                {
                                    itemEntry.Qty += qty;
                                }

                                matchFound = true;
                            }
                        }
                        break;
                    }
                }

                if (!matchFound)
                {
                    invalidLines.Add(line);
                }
            }

            var skills = _playerService.GetReprocessingSkills();

            var viewModel = new OreListModel
            {
                Skills = skills,
                DesiredMinerals = mineralList,
                TextInput = textInput,
                InvalidLines = invalidLines,
                UseCompressedOres = useCompressedOres,
                Multiplier = multiplier,
                BuildShips = buildShips,
            };

            if (mineralList.TotalVolume > 0)
            {
                var compressedOres = _itemService.GetCompressedOres(skills, mineralList);
                foreach (var ore in compressedOres.MarketItems)
                {
                    itemList.Add(new ItemLookup
                    {
                        TypeId = ore.Id,
                        Qty = (int)ore.Qty,
                    });
                }
            }

            if (itemList.Any())
            {

                viewModel.ItemOrderSummary = _itemService.GetItemPricing(itemList, 300, .02m, 60003760);


            }
            viewModel.TextInput = textInput;
            viewModel.InvalidLines = invalidLines;

            return View("OreCalculator", viewModel);
        }
    }
}