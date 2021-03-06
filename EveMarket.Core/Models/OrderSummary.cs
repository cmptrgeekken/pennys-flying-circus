﻿using System.Collections.Generic;
using EveMarket.Core.Models.FlyingCircus;

namespace EveMarket.Core.Models
{
    public class OrderSummary
    {
        public List<Mineral> Minerals { get; set; }
        public MineralQuote MineralQuote { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal TotalVolume { get; set; }
        public double? TotalMineralVolume { get; set; }
        public decimal SourceStagingShippingCost { get; set; }
        public decimal ProfitSell { get; set; }
        public decimal PredictedSell { get; set; }
        public decimal PredictedProfit { get; set; }
        public decimal PurchaseCostBest { get; set; }
        public decimal? MineralValueRatio { get; set; }
        public IEnumerable<MarketItem> MarketItems { get; set; }
    }
}
