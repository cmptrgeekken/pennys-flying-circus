using EveMarket.Core.Enums;

namespace EveMarket.Core.Models
{
    public class OreMinerals : MarketItem
    {
        public double YieldModifier { get; set; }
        public ReprocessingType ReprocessingType { get; set; }
        
        public MineralList ReprocessedMinerals { get; set; }
        public double ReprocessingRate { get; set; }

        public double GetMineralQty(MineralType mineralType, double reprocessingRate)
        {
            return ReprocessedMinerals[mineralType]*Qty*reprocessingRate;
        }
    }
}
