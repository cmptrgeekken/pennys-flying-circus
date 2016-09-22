using System;

namespace EveMarket.Core.Models
{
    public class MarketItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Qty { get; set; }
        public double Volume { get; set; }
        public ItemPricing Pricing { get; set; }
        public decimal TotalPrice => Math.Round((decimal)Pricing.CalculateBuyAllTotal((int) Math.Ceiling(Qty)), 2);
        public decimal TotalPriceBest => Math.Round((decimal)Pricing.CalculateBestTotal((int) Math.Ceiling(Qty)), 2);
        public decimal AveragePrice => Qty > 0 ? Math.Round(TotalPrice / (decimal)Qty, 2) : 0;
        public decimal AverageShippingCost => AveragePrice*CollateralPct + (decimal)Volume*IskPerM3;
        public double TotalVolume => Qty*Volume;
        public decimal IskPerM3 { get; set; }
        public decimal CollateralPct { get; set; }
    }
}
