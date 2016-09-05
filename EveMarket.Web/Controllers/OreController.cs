using EveMarket.Core.Models;
using EveMarket.Core.Repositories;
using EveMarket.Core.Services;
using EveMarket.Web.Models;
using eZet.EveLib.EveCentralModule;
using System.Collections.Generic;
using System.Web.Mvc;
using EveMarket.Core.Repositories.Db;

namespace EveMarket.Web.Controllers
{
    public class OreController : Controller
    {
        private readonly ItemService _itemService;
        private readonly PlayerService _playerService;

        public OreController()
        {
            _itemService = new ItemService(new EveDb(), new EveCentral(), new EveMarketDataEntities());
            _playerService = new PlayerService(new EveDb());
        }


        // GET: Ore
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReprocessingCalculator(MineralList desiredMinerals)
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
    }
}