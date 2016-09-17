using System;
using System.Collections.Generic;

namespace EveMarket.Core.Models.FlyingCircus
{
    public class RegionMarketOrder
    {
        public long TypeId { get; set; }
        public long RegionId { get; set; }

        public IEnumerable<MarketOrder> MarketOrders { get; set; }

        public DateTime LastUpdated { get; set; }
        
    }
}
