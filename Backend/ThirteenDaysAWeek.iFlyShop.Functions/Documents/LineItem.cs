using Newtonsoft.Json;

namespace ThirteenDaysAWeek.iFlyShop.Functions.Documents
{
    public class LineItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public string OrderNumber { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
