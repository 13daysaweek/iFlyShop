namespace ThirteenDaysAWeek.iFlyShop.Api.Configuration
{
    public interface IAppConfiguration
    {
        string OrderQueueName { get; }

        string StorageConnectionString { get; }

        string CorsAllowedHosts { get; }

        string CorsAllowedHeaders { get; }

        string CorsAllowedMethods { get; }

        void Initialize();
    }
}