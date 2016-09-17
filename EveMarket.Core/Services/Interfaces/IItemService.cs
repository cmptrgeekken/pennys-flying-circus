using System.Collections.Generic;
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
        OrderSummary GetItemPricing(List<ItemLookup> itemList);
    }
}
