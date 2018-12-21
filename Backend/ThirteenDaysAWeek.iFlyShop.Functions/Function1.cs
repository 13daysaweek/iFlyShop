using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ThirteenDaysAWeek.iFlyShop.Functions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("orders", Connection = "ordersQueueConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
