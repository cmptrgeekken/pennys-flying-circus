using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveMarket.Core.Models
{
    public class BlueprintSkill
    {
        public long SkillId { get; set; }
        public string SkillName { get; set; }
        public long MinimumLevel { get; set; }
    }
}
