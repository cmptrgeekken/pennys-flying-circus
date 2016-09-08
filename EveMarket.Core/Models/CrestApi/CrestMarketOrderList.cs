using System.Collections.Generic;
using Newtonsoft.Json;

namespace EveMarket.Core.Models.CrestApi
{
    public class CrestMarketOrderList
    {
        public IEnumerable<CrestMarketOrder> Items { get; set; }

        public int TotalCount { get; set; }

        public int PageCount { get; set; }
        [JsonProperty("next.href")]
        public string Next { get; set; }
    }
}
