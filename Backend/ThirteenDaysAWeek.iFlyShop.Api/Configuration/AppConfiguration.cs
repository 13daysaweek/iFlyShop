using System.Configuration;

namespace ThirteenDaysAWeek.iFlyShop.Api.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public string OrderQueueName { get; private set; }
        
        public string StorageConnectionString { get; private set; }

        public void Initialize()
        {
            OrderQueueName = ConfigurationManager.AppSettings["orderQueueName"];
            StorageConnectionString = ConfigurationManager.ConnectionStrings["storageConnectionString"].ConnectionString;
        }
    }
}