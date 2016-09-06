using EveMarket.Core.Models.CrestApi;

namespace EveMarket.Core.Models
{
    public class AdjustedMarketOrder
    {
        public decimal AdjustedPrice { get; set; }
        public int Volume { get; set; }
        public OreMinerals AssociatedOre { get; set; }
        public decimal Price { get; set; }
        public long StationId { get; set; }
        public string StationName { get; set; }
    }
}
