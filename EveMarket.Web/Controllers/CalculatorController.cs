using System;
using System.Collections.Generic;
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

        public JsonResult GetMaterialCosts(BlueprintCalculationViewModel viewModel)
        {

            var mineralList = new MineralList();
            var mineralNames = mineralList.GetMineralNames().ToList();

            var oreList = new Dictionary<long, ItemLookup>();
            var itemList = new Dictionary<long,ItemLookup>();
            var blueprints = new Dictionary<long, BlueprintLookupViewModel>();
            foreach (var bp in viewModel.Blueprints)
            {
                var bpMaterials = bp.Materials.SelectMany(m => m.FlattenHierarchy(h => h.Materials));
                foreach (var material in bpMaterials)
                {
                    if (!material.BuildComponents)
                    {
                        var item = _itemService.GetItem(material.TypeId);
                        if (viewModel.CompressMinerals && mineralNames.Contains(item.typeName))
                        {
                            mineralList[item.typeName] += material.Qty;
                        }
                        else
                        {
                            if (!itemList.ContainsKey(material.TypeId))
                            {
                                itemList.Add(material.TypeId, new ItemLookup
                                {
                                    TypeId = material.TypeId,
                                    Qty = 0
                                });
                            }

                            itemList[material.TypeId].Qty += material.Qty;
                        }
                    }
                    else
                    {
                        if (!blueprints.ContainsKey(material.TypeId))
                        {
                            blueprints.Add(material.TypeId, new BlueprintLookupViewModel()
                            {
                                TypeId = material.TypeId,
                                JobCost = material.JobBaseCost * viewModel.MfgSystemCostIndex,
                            });
                        }

                        blueprints[material.TypeId].Qty += material.Qty;
                    }
                }

                if (!blueprints.ContainsKey(bp.TypeId))
                {
                    blueprints.Add(bp.TypeId, new BlueprintLookupViewModel
                    {
                        TypeId = bp.TypeId,
                        JobCost = bp.JobBaseCost * viewModel.MfgSystemCostIndex,
                    });
                }

                blueprints[bp.TypeId].Qty += bp.Qty;
            }

            var skills = _playerService.GetReprocessingSkills();
            if (mineralList.TotalVolume > 0)
            {
                var compressedOres = _itemService.GetCompressedOres(skills, mineralList);
                foreach (var ore in compressedOres.MarketItems)
                {
                    oreList.Add(ore.Id, new ItemLookup
                    {
                        TypeId = ore.Id,
                        Qty = (int)ore.Qty,
                    });
                }
            }

            OrderSummary oreSummary = null;
            OrderSummary orderSummary = null;

            if (oreList.Any())
            {
                oreSummary = _itemService.GetItemPricing(oreList.Values.ToList());
            }

            if (itemList.Any())
            {
                orderSummary = _itemService.GetItemPricing(itemList.Values.ToList());
            }

            return Json(new BlueprintCalculationResultsViewModel
            {
                OreSummary = oreSummary,
                OrderSummary = orderSummary,
                BlueprintSummary = blueprints.Values.ToList(),
            });
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

                viewModel.ItemOrderSummary = _itemService.GetItemPricing(itemList);
                
                
            }
            viewModel.TextInput = textInput;
            viewModel.InvalidLines = invalidLines;

            return View("OreCalculator", viewModel);
        }
    }
}