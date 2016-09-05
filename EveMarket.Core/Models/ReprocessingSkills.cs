using System;
using EveMarket.Core.Enums;
using System.Reflection;

namespace EveMarket.Core.Models
{
    public class ReprocessingSkills
    {
        public int Reprocessing { get; set; }
        public int ReprocessingEfficiency { get; set; }
        public int ArkonorProcessing { get; set; }
        public int BistotProcessing { get; set; }
        public int CrokiteProcessing { get; set; }
        public int DarkOchreProcessing { get; set; }
        public int GneissProcessing { get; set; }
        public int HedbergiteProcessing { get; set; }
        public int HemorphiteProcessing { get; set; }
        public int JaspetProcessing { get; set; }
        public int KerniteProcessing { get; set; }
        public int MercoxitProcessing { get; set; }
        public int OmberProcessing { get; set; }
        public int PlagioclaseProcessing { get; set; }
        public int PyroxeresProcessing { get; set; }
        public int ScorditeProcessing { get; set; }
        public int SpodumainProcessing { get; set; }
        public int VeldsparProcessing { get; set; }
        public int ScrapmetalProcessing { get; set; }
        public int IceProcessing { get; set; }
        public int ImplantLevel { get; set; }
        public double StationRate { get; set; }

        public double CalculateReprocessingRate(ReprocessingType reprocessingType)
        {
            var reprocessingRate = StationRate*(1 + .02*ReprocessingEfficiency)*(1 + .03*Reprocessing)*(1+ImplantLevel*.01);

            var reprocessingSkillAttribute = GetType().GetRuntimeProperty($"{reprocessingType}Processing");
            if (reprocessingSkillAttribute == null)
            {
                throw new NotImplementedException($"Property {reprocessingType}Processing not found on {nameof(ReprocessingSkills)} class.");
            }

            var reprocessingSkillLevel = (int?) reprocessingSkillAttribute?.GetValue(this) ?? 0;

            return reprocessingRate*(1 + .02*reprocessingSkillLevel);
        }
    }
}
