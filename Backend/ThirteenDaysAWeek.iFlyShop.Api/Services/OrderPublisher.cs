using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using ThirteenDaysAWeek.iFlyShop.Api.Configuration;
using ThirteenDaysAWeek.iFlyShop.Api.Telemetry;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Services
{
    public class OrderPublisher : IOrderPublisher
    {
        private readonly IAppConfiguration _configuration;
        private readonly ITelemetryService _telemetryService;
        private readonly CloudStorageAccount _storageAccount;

        public OrderPublisher(IAppConfiguration configuration, ITelemetryService telemetryService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _telemetryService = telemetryService ?? throw new ArgumentNullException(nameof(telemetryService));
            _storageAccount = CloudStorageAccount.Parse(_configuration.StorageConnectionString);
            CreateQueue();
        }

        public async Task SubmitOrderAsync(Order order)
        {
            var queueClient = _storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(_configuration.OrderQueueName);
            var messageContent = JsonConvert.SerializeObject(order);
            var message = new CloudQueueMessage(messageContent);

            await queue.AddMessageAsync(message);

            var args = new Dictionary<string, string>
            {
                {"customerId", order.CustomerId.ToString()},
                {"orderNumber", order.OrderNumber}
            };
            _telemetryService.LogEvent(Constants.Events.OrderPublishedEvent, args);
        }

        private void CreateQueue()
        {
            var queueClient = _storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(_configuration.OrderQueueName);
            queue.CreateIfNotExists();
        }
    }
}