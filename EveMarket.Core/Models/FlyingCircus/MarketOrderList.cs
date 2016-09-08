using System;
using System.Collections.Generic;

namespace EveMarket.Core.Models.FlyingCircus
{
    public class MarketOrderList
    {
        public long TypeId { get; set; }
        public IEnumerable<MarketOrder> Orders { get; set; }
        public DateTime LastUpdated { get; set; }
        public long RegionId { get; set; }
    }
}
