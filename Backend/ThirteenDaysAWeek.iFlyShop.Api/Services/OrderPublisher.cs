using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using ThirteenDaysAWeek.iFlyShop.Api.Configuration;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Services
{
    public class OrderPublisher : IOrderPublisher
    {
        private readonly IAppConfiguration _configuration;
        private readonly CloudStorageAccount _storageAccount;

        public OrderPublisher(IAppConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
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
        }

        private void CreateQueue()
        {
            var queueClient = _storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(_configuration.OrderQueueName);
            queue.CreateIfNotExists();
        }
    }
}