using System;
using System.Collections.Generic;

namespace EveMarket.Core.Models.FlyingCircus
{
    public class ImportItem
    {
        public Guid Id { get; set; }
        public long TypeId { get; set; }
        public long RegionId { get; set; }
        public DateTime? LastUpdate { get; set; }

        public virtual IEnumerable<MarketOrder> MarketOrders { get; set; }
    }
}
