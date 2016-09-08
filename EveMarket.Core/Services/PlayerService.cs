using EveMarket.Core.Models;
using EveMarket.Core.Repositories;
using EveMarket.Core.Services.Interfaces;

namespace EveMarket.Core.Services
{
    public class PlayerService : IPlayerService
    {

        public ReprocessingSkills GetReprocessingSkills()
        {
            // var skillGroup = _eveDb.invGroups.First(g => g.groupName == "Resource Processing");
            // var skills = skillGroup.invTypes.Where(t => t.typeName.ToLowerInvariant().Contains("processing"));

            return new ReprocessingSkills
            {
                ArkonorProcessing = 4,
                BistotProcessing = 4,
                CrokiteProcessing = 4,
                DarkOchreProcessing = 4,
                GneissProcessing = 4,
                HedbergiteProcessing = 4,
                HemorphiteProcessing = 5,
                Reprocessing = 5,
                ReprocessingEfficiency = 5,
                OmberProcessing = 4,
                MercoxitProcessing = 4,
                KerniteProcessing = 5,
                IceProcessing = 0,
                SpodumainProcessing = 4,
                JaspetProcessing = 4,
                VeldsparProcessing = 5,
                PyroxeresProcessing = 5,
                ScrapmetalProcessing = 0,
                PlagioclaseProcessing = 5,
                ScorditeProcessing = 5,
                StationRate = .6048,
                ImplantLevel = 4,
            };
        }
    }
}
