using System;
using Newtonsoft.Json;

namespace ThirteenDaysAWeek.iFlyShop.Functions.Documents
{
    public class OrderHeader
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public string OrderNumber { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
