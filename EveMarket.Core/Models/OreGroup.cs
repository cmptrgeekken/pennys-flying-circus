using EveMarket.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace EveMarket.Core.Models
{
    public class OreGroup
    {
        public string GroupName { get; set; }
        
        public IEnumerable<OreMinerals> Ores { get; set; }

        public IEnumerable<AdjustedMarketOrder> OptimizedMarketOrders
        {
            get
            {
                var allMarketOrders = Ores.SelectMany(o => o.Pricing.AllowedMarketOrders.Select(mo => new AdjustedMarketOrder
                {
                    Price = mo.Price,
                    AdjustedPrice = mo.Price * (decimal)(1-o.YieldModifier),
                    Volume = mo.Volume,
                    StationId = mo.StationId,
                    StationName = mo.StationName,
                    AssociatedOre = o,
                })).OrderBy(mo => mo.AdjustedPrice);

                return allMarketOrders;
            }
        }

        public ReprocessingType ReprocessingType { get; set; }
    }
}
