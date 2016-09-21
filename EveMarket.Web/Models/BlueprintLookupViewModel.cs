using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveMarket.Web.Models
{
    public class BlueprintLookupViewModel
    {
        public long TypeId { get; set; }
        public int Qty { get; set; }
        public double JobCost { get; set; }
    }
}