using System.Collections.Generic;
using EveMarket.Core.Models;

namespace EveMarket.Web.Models
{
    public class OreListModel
    {
        public ReprocessingSkills Skills { get; set; }
        public MineralList DesiredMinerals { get; set; }
        public OrderSummary OreOrderSummary { get; set; }
        public OrderSummary ItemOrderSummary { get; set; }
        public string TextInput { get; set; }
        public List<string> InvalidLines { get; set; }
        public bool UseCompressedOres { get; set; } = true;
        public int Multiplier { get; set; } = 1;
        public bool BuildShips { get; set; }
    }
}