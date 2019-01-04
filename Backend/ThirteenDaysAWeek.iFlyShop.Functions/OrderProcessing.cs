using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ThirteenDaysAWeek.iFlyShop.Functions.Documents;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;

namespace ThirteenDaysAWeek.iFlyShop.Functions
{
    public static class OrderProcessing
    {
        private static string _iKey = TelemetryConfiguration.Active.InstrumentationKey = Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY", EnvironmentVariableTarget.Process);
        private static TelemetryClient _telemetryClient = new TelemetryClient() { InstrumentationKey = _iKey };

        [FunctionName("OrderProcessing")]
        public static void Run([QueueTrigger("orders", Connection = "ordersQueueConnectionString")]string myQueueItem, 
            [CosmosDB(
            databaseName: "order-processing",
            collectionName:"orders", 
            ConnectionStringSetting = "orderProcessingConnectionString")] out OrderHeader header, 
            [CosmosDB(databaseName: "order-processing",
                collectionName: "order-items",
                ConnectionStringSetting = "orderProcessingConnectionString")] ICollector<LineItem> lineItems,
            ILogger log,
            ExecutionContext context)
        {
            _telemetryClient.Context.Operation.Id = context.InvocationId.ToString();
            _telemetryClient.Context.Operation.Name = nameof(OrderProcessing);

            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            var order = JsonConvert.DeserializeObject<Order>(myQueueItem);
            var orderHeader = new OrderHeader
            {
                CustomerId = order.CustomerId,
                Id = Guid.NewGuid().ToString(),
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber
            };

            var items = order.Items.Select(_ => new LineItem
            {
                ProductId = _.ProductId,
                Quantity = _.Quantity,
                OrderNumber = orderHeader.OrderNumber,
                Id = Guid.NewGuid().ToString()
            });

            header = orderHeader;

            foreach (var item in items)
            {
                lineItems.Add(item);
            }

            var args = new Dictionary<string, string>
            {
                {"customerId", order.CustomerId.ToString()},
                {"orderNumber", order.OrderNumber}
            };
            _telemetryClient.TrackEvent(Constants.Events.OrderProcessedEvent, args);
        }
    }
}
