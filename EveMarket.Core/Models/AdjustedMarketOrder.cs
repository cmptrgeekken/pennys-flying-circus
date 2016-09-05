using EveMarket.Core.Models.CrestApi;

namespace EveMarket.Core.Models
{
    public class AdjustedMarketOrder
    {
        public double AdjustedPrice { get; set; }
        public int Volume { get; set; }
        public MarketOrderLocation Location { get; set; }
        public OreMinerals AssociatedOre { get; set; }
        public double Price { get; set; }
    }
}
