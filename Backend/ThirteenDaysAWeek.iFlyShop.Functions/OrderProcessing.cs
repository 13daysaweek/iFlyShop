using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;

namespace ThirteenDaysAWeek.iFlyShop.Functions
{
    public static class OrderProcessing
    {
        [FunctionName("OrderProcessing")]
        public static void Run([QueueTrigger("orders", Connection = "ordersQueueConnectionString")]string myQueueItem, 
            [CosmosDB(
            databaseName: "order-processing",
            collectionName:"orders", 
            ConnectionStringSetting = "orderProcessingConnectionString")] out Order outputOrder, 
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            var order = JsonConvert.DeserializeObject<Order>(myQueueItem);
            outputOrder = order;
        }
    }
}
