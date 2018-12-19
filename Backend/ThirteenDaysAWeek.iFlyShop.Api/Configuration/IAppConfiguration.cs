namespace ThirteenDaysAWeek.iFlyShop.Api.Configuration
{
    public interface IAppConfiguration
    {
        string OrderQueueName { get; }

        string StorageConnectionString { get; }

        void Initialize();
    }
}