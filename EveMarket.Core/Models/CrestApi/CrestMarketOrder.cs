using System;

namespace EveMarket.Core.Models.CrestApi
{
    public class CrestMarketOrder
    {
        public long Id { get; set; }
        public long StationId { get; set; }
        public long Type { get; set; }
        public bool Buy { get; set; }
        public DateTime Issued { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public int Duration { get; set; }
        public int MinVolume { get; set; }
        public int VolumeEntered { get; set; }
        public string Range { get; set; }
    }
}
