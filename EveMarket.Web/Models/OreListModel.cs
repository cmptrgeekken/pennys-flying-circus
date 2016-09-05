using EveMarket.Core.Models;

namespace EveMarket.Web.Models
{
    public class OreListModel
    {
        public ReprocessingSkills Skills { get; set; }
        public MineralList DesiredMinerals { get; set; }
        public OrderSummary OrderSummary { get; set; }
    }
}