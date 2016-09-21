using System.Collections.Generic;
using System.Linq;
using EveMarket.Core.Extensions;

namespace EveMarket.Web.Models
{
    public class BlueprintViewModel
    {
        public long TypeId { get; set; }
        public int Qty { get; set; }
        public int TimeEfficiency { get; set; }
        public int MaterialEfficiency { get; set; }
        public bool BuildComponents { get; set; }
        public decimal BlueprintPackCost { get; set; }
        public double JobBaseCost { get; set; }
        public IEnumerable<BlueprintMaterialViewModel> Materials { get; set; }

        public IEnumerable<BlueprintMaterialViewModel> AllMaterials
        {
            get { return Materials.Union(Materials.SelectMany(m => m.FlattenHierarchy(h => h.Materials))).Where(m => !m.BuildComponents); }
        }
    }
}