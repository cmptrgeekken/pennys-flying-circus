using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveMarket.Core.Models
{
    public class Blueprint
    {
        public long TypeId { get; set; }
        public string TypeName { get; set; }
        public bool BuildComponents { get; set; } = true;
        public decimal BpcPackCost { get; set; }
        public int MaterialEfficiency { get; set; } = 10;
        public int TimeEfficiency { get; set; } = 20;
        public int Qty { get; set; } = 1;
        public IEnumerable<BlueprintSkill> Skills { get; set; }
        public IEnumerable<BlueprintMaterial> Materials { get; set; }
    }
}
