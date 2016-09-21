using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EveMarket.Core.Models;

namespace EveMarket.Web.Models
{
    public class BlueprintCalculationResultsViewModel
    {
        public OrderSummary OreSummary { get; set; }
        public OrderSummary OrderSummary { get; set; }
        public IEnumerable<BlueprintLookupViewModel> BlueprintSummary { get; set; }
    }
}