using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EveMarket.Core.Models;

namespace EveMarket.Web.Models
{
    public class BlueprintCalculationResultsViewModel
    {
        public BlueprintCalculationResultsViewModel()
        {
            BlueprintResults = new List<BlueprintCalculationResultViewModel>();
        }
        public OrderSummary OreSummary { get; set; }
        public OrderSummary OrderSummary { get; set; }

        public decimal PurchaseCost
        {
            get { return OreSummary.PurchaseCost + OrderSummary.PurchaseCost; }
        }

        public decimal ShippingCost
        {
            get { return OrderSummary.SourceStagingShippingCost + OreSummary.SourceStagingShippingCost; }
        }

        public decimal TotalCost
        {
            get { return PurchaseCost + ShippingCost; }
        }

        

        public List<BlueprintCalculationResultViewModel> BlueprintResults { get; set; }
        public BpcResultsViewModel BpcResults { get; set; }
    }
}