using System.Collections.Generic;
using EveMarket.Core.Models.FlyingCircus;

namespace EveMarket.Core.Models
{
    public class OrderSummary
    {
        public IEnumerable<OreMinerals> Ores { get; set; }
        public List<Mineral> Minerals { get; set; }
        public MineralQuote MineralQuote { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal TotalOreVolume { get; set; }
        public double TotalMineralVolume { get; set; }
        public decimal SourceStagingShippingCost { get; set; }
        public double StagingRefineryShippingCost { get; set; }
        public double RefiningCost { get; set; }
        public double RefineryStationShippingCost { get; set; }
        public decimal ProfitSell { get; set; }
        public decimal PredictedSell { get; set; }
        public decimal PredictedProfit { get; set; }
        public decimal PurchaseCostBest { get; set; }
        public decimal MineralValueRatio { get; set; }
    }
}
