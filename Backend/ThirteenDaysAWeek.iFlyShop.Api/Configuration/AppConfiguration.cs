using System.Configuration;

namespace ThirteenDaysAWeek.iFlyShop.Api.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public string OrderQueueName { get; private set; }
        
        public string StorageConnectionString { get; private set; }

        public string CorsAllowedHosts { get; private set; }

        public string CorsAllowedHeaders { get; private set; }

        public string CorsAllowedMethods { get; private set; }

        public void Initialize()
        {
            OrderQueueName = ConfigurationManager.AppSettings["orderQueueName"];
            StorageConnectionString = ConfigurationManager.ConnectionStrings["storageConnectionString"].ConnectionString;
            CorsAllowedHosts = ConfigurationManager.AppSettings["cors:AllowedHosts"];
            CorsAllowedHeaders = ConfigurationManager.AppSettings["cors:AllowedHeaders"];
            CorsAllowedMethods = ConfigurationManager.AppSettings["cors:AllowedMethods"];
        }
    }
}