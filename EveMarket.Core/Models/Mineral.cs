using EveMarket.Core.Enums;

namespace EveMarket.Core.Models
{
    public class Mineral : BaseMarketItem
    {
        public MineralType MineralType { get; set; }
        public ReprocessingType PrimaryOreReprocessingType { get; set; }
        public int ReprocessingOrder { get; set; }
        public decimal ComparisonPrice { get; set; }
        public double DesiredQty { get; set; }
        public decimal ComparisonTotal { get; set; }
    }
}
