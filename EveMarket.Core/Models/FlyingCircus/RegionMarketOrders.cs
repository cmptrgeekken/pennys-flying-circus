using System;
using System.Collections.Generic;

namespace EveMarket.Core.Models.FlyingCircus
{
    public class RegionMarketOrders
    {
        public long RegionId { get; set; }
        public string RegionName { get; set; }
        public IEnumerable<MarketOrderList> MarketOrders { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
