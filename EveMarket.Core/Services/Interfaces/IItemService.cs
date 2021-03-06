﻿using System.Collections.Generic;
using System.Linq;
using EveMarket.Core.Enums;
using EveMarket.Core.Models;
using EveMarket.Core.Repositories.Eve;

namespace EveMarket.Core.Services.Interfaces
{
    public interface IItemService
    {
        List<OreGroup> GetOreGroups(ReprocessingSkills reprocessingSkills);
        List<Mineral> GetMinerals();
        OrderSummary GetCompressedOres(ReprocessingSkills reprocessingSkills, MineralList mineralList);
        OrderSummary GetOrderSummary(IEnumerable<MarketItem> ores, List<Mineral> minerals, MineralList mineralList);
        ItemPricing GetCurrentItemPricing(long typeId, long regionId = 10000002, IEnumerable<long> stationIds = null);
        void RefreshMarketOrders(long regionId);
        invType GetItem(string itemName);
        OrderSummary GetItemPricing(List<ItemLookup> itemList, decimal iskPerM3, decimal collateralPct, long stationId);
        IEnumerable<Blueprint> GetBlueprints(string name);
        Blueprint GetBlueprint(int typeId, IndustryActivityType activityType);
        IEnumerable<mapSolarSystem> GetSystems(string prefix);
        IEnumerable<staStation> GetStations(int systemId, string prefix);
        invType GetItem(long itemId);
    }
}
