using System;
using EveMarket.Core.Models;
using EveMarket.Core.Repositories;
using EveMarket.Core.Services;
using EveMarket.Web.Models;
using eZet.EveLib.EveCentralModule;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using EveMarket.Core.Repositories.Db;

namespace EveMarket.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ItemService _itemService;
        private readonly PlayerService _playerService;

        public CalculatorController()
        {
            _itemService = new ItemService(new EveDb(), new FlyingCircusEntities());
            _playerService = new PlayerService(new EveDb());
        }


        // GET: Ore
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult OreCalculator(MineralList desiredMinerals)
        {
            var skills = _playerService.GetReprocessingSkills();

            var viewModel = new OreListModel
            {
                Skills = skills,
                DesiredMinerals = desiredMinerals,
            };

            if (desiredMinerals.TotalVolume > 0)
            {
                viewModel.OrderSummary = _itemService.GetCompressedOres(skills, desiredMinerals);
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ParseItems(string textInput)
        {

            var inputTests = new []
            {
                new Regex(@"^(?<itemQty>[\d,]+)x?\s+(?<itemName>[^\t]+)"),
                new Regex(@"^(?<itemName>[^\t]+)\tx?(?<itemQty>[\d,]+x?)"),
                new Regex(@"^(?<itemName>[^\d\t]+)"),
            };

            var lines = textInput.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);

            var mineralList = new MineralList();
            var mineralNames = mineralList.GetMineralNames().ToList();

            foreach (var line in lines)
            {
                foreach (var inputTest in inputTests)
                {
                    var inputMatch = inputTest.Match(line);
                    if (inputMatch.Success)
                    {
                        var itemQty = inputMatch.Groups["itemQty"];
                        var itemName = inputMatch.Groups["itemName"].Value;

                        if (mineralNames.Contains(itemName))
                        {
                            var qty = itemQty.Success ? int.Parse(itemQty.Value.Replace(",","")) : 1;

                            mineralList[itemName] += qty;
                        }
                        break;
                    }
                }
            }

            return RedirectToAction("OreCalculator", mineralList);
        }

        [HttpGet]
        public ActionResult UpdateItemDb()
        {
            _itemService.UpdateMarketOrders();

            return Content("Success");
        }
    }
}