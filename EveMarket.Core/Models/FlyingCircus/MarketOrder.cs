using System;

namespace EveMarket.Core.Models.FlyingCircus
{
    public class MarketOrder
    {
        public Guid Id { get; set; }
        public Guid ImportItemId { get; set; }
        public long TypeId { get; set; }
        public long StationId { get; set; }
        public string StationName { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
    }
}
