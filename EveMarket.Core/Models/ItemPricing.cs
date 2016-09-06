using EveMarket.Core.Models.CrestApi;
using eZet.EveLib.EveMarketDataModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using EveMarket.Core.Repositories.Db;

namespace EveMarket.Core.Models
{
    public class ItemPricing
    {
        public long RegionId { get; set; }
        public IEnumerable<long> AllowedStationIds { get; set; }
        public IEnumerable<MarketOrder> MarketOrders { get; set; }

        public IEnumerable<MarketOrder> AllowedMarketOrders
        {
            get { return MarketOrders.Where(o => AllowedStationIds.Contains(o.StationId)); }
        }
        public ItemHistory ItemHistory { get; set; }

        public int TotalQty
        {
            get { return MarketOrders.Sum(o => o.Volume); }
        }

        public DateTime? LastUpdated { get; set; }

        public decimal CalculateBestTotal(int qty)
        {
            var remainingQty = qty;
            var ttlCost = 0.0m;
            foreach(var order in AllowedMarketOrders)
            {

                var orderVolume = order.Volume;

                var currentQty = Math.Min(remainingQty, orderVolume);

                ttlCost += currentQty*order.Price;

                remainingQty -= currentQty;

                if (remainingQty <= 0) break;
            }

            return ttlCost;
        }

        public decimal CalculateBuyAllTotal(int qty)
        {
            var remainingQty = qty;
            foreach (var order in AllowedMarketOrders)
            {
                remainingQty -= order.Volume;
                if (remainingQty <= 0)
                {
                    return qty*order.Price;
                };
            }

            return -1;
        }
    }
}
