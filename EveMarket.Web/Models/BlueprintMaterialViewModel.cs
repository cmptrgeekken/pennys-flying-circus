using System.Collections.Generic;

namespace EveMarket.Web.Models
{
    public class BlueprintMaterialViewModel
    {
        public long TypeId { get; set; }
        public int Qty { get; set; }
        public int MaterialEfficiency { get; set; }
        public int TimeEfficiency { get; set; }
        public bool BuildComponents { get; set; }
        public double JobBaseCost { get; set; }
        public IEnumerable<BlueprintMaterialViewModel> Materials { get; set; }
    }
}