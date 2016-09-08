using System;

namespace EveMarket.Core.Models.FlyingCircus
{
    public class MineralQuote
    {
        public System.Guid Id { get; set; }
        public string QuoteLookup { get; set; }
        public string PlayerName { get; set; }
        public int? TritaniumQty { get; set; }
        public int? PyeriteQty { get; set; }
        public int? MexallonQty { get; set; }
        public int? IsogenQty { get; set; }
        public int? NocxiumQty { get; set; }
        public int? ZydrineQty { get; set; }
        public int? MegacyteQty { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Shipping { get; set; }
        public decimal? Total { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int? MorphiteQty { get; set; }
    }
}
