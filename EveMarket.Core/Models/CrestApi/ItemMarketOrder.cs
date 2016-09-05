using System;

namespace EveMarket.Core.Models.CrestApi
{
    public class ItemMarketOrder
    {
        public long Id { get; set; }
        public double Price { get; set; }
        public int Volume { get; set; }
        public MarketOrderLocation Location { get; set; }
        public MarketOrderType Type { get; set; }
    }
}
