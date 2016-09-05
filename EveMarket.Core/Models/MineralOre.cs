using EveMarket.Core.Enums;

namespace EveMarket.Core.Models
{
    public class MineralOre
    {
        public MineralType MineralType { get; set; }
        public int EvaluationOrder { get; set; }
        public ReprocessingType PrimaryOreReprocessingType { get; set; }
    }
}
