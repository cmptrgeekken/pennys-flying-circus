using EveMarket.Core.Models.CrestApi;
using eZet.EveLib.EveMarketDataModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EveMarket.Core.Models
{
    public class ItemPricing
    {
        public long RegionId { get; set; }
        public IEnumerable<long> AllowedStationIds { get; set; }
        public IEnumerable<ItemMarketOrder> MarketOrders { get; set; }

        public IEnumerable<ItemMarketOrder> AllowedMarketOrders
        {
            get { return MarketOrders.Where(o => AllowedStationIds.Contains(o.Location.Id)); }
        }
        public ItemHistory ItemHistory { get; set; }

        public int TotalQty
        {
            get { return MarketOrders.Sum(o => o.Volume); }
        }

        public double CalculateBestTotal(int qty)
        {
            var remainingQty = qty;
            var ttlCost = 0.0;
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

        public double CalculateBuyAllTotal(int qty)
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
