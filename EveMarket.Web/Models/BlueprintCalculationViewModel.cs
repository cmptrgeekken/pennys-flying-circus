using System.Collections.Generic;

namespace EveMarket.Web.Models
{
    public class BlueprintCalculationViewModel
    {
        public double MfgSystemCostIndex { get; set; }
        public bool CompressMinerals { get; set; }
        public long PurchaseStationId { get; set; }
        public IEnumerable<BlueprintViewModel> Blueprints { get; set; }
        public IEnumerable<SkillLevelViewModel> Skills { get; set; }
    }
}