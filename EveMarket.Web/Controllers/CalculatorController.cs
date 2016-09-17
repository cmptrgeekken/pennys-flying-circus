using System;
using System.Collections.Generic;
using EveMarket.Core.Models;
using EveMarket.Web.Models;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using eZet.EveLib.EveAuthModule;
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

        public JsonResult GetBlueprints(string prefix)
        {
            return Json("");
        }

        public ActionResult BlueprintCalculator()
        {
            return View();
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