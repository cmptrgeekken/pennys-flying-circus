using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveMarket.Web.Models
{
    public class BpcResultsViewModel
    {
        public BpcResultsViewModel()
        {
            Blueprints = new List<BlueprintLookupViewModel>();
        }
        public List<BlueprintLookupViewModel> Blueprints { get; set; }

        public decimal TotalCost
        {
            get { return Blueprints.Sum(bp => (decimal)(bp.JobCost*bp.Qty)); }
        }
    }
}