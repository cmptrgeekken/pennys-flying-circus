using System.Collections.Generic;

namespace EveMarket.Core.Models.CrestApi
{
    public class ItemMarketOrders
    {
        public int TotalCount { get; set; }
        public IEnumerable<ItemMarketOrder> Items { get; set; }
        public int PageCount { get; set; }
    }
}
