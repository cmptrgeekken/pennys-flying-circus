using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveMarket.Core.Models
{
    public class BlueprintMaterial
    {
        private bool? _buildComponents;
        public long? Qty { get; set; }
        public long TypeId { get; set; }
        public string TypeName { get; set; }
        public double Volume { get; set; }
        public bool BuildComponents
        {
            get
            {
                if (!_buildComponents.HasValue)
                {
                    _buildComponents = Materials.Any();
                }
                return _buildComponents.Value;
            }
            set { _buildComponents = value; }
        }
        public int MaterialEfficiency { get; set; } = 10;
        public int TimeEfficiency { get; set; } = 20;
        public IEnumerable<BlueprintMaterial> Materials { get; set; }
        public IEnumerable<BlueprintSkill> Skills { get; set; }
    }
}
