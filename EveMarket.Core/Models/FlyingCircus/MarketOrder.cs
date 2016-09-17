using System;
using LiteDB;

namespace EveMarket.Core.Models.FlyingCircus
{
    public class MarketOrder
    {
        public long TypeId { get; set; }
        public long StationId { get; set; }
        [BsonIgnore]
        public string StationName { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
    }
}
