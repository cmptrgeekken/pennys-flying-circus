using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveMarket.Web.Models
{
    public class BlueprintCalculationResultViewModel
    {
        public long TypeId { get; set; }
        public string TypeName { get; set; }
        public decimal MaterialPrice { get; set; }
        public decimal BlueprintPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int Qty { get; set; }
    }
}