using System.Collections.Generic;
using EveMarket.Core.Models;

namespace EveMarket.Core.Services.Interfaces
{
    public interface IItemService
    {
        List<OreGroup> GetOreGroups(ReprocessingSkills reprocessingSkills);
        List<Mineral> GetMinerals();
        OrderSummary GetCompressedOres(ReprocessingSkills reprocessingSkills, MineralList mineralList);
        OrderSummary GetOrderSummary(IEnumerable<OreMinerals> ores, List<Mineral> minerals, MineralList mineralList);
        ItemPricing GetCurrentItemPricing(long typeId, long regionId = 10000002, IEnumerable<long> stationIds = null);
        void RefreshMarketOrders(long regionId);
    }
}
