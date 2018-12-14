using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ThirteenDaysAWeek.iFlyShop.Api.Caching
{
    public class CacheAccessor : ICacheAccessor
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public CacheAccessor(string cacheConnectionString)
        {
            if (string.IsNullOrWhiteSpace(cacheConnectionString))
            {
                throw new ArgumentException(Strings.CacheAccessor_Empty_ConnectionString_Message, nameof(cacheConnectionString));
            }

            _connectionMultiplexer = ConnectionMultiplexer.Connect(cacheConnectionString);
        }

        public async Task<TCacheItem> GetAsync<TCacheItem>(string cacheKey)
        {
            var item = default(TCacheItem);
            var database = _connectionMultiplexer.GetDatabase();
            var itemString = await database.StringGetAsync(cacheKey);

            if (!string.IsNullOrWhiteSpace(itemString))
            {
                item = JsonConvert.DeserializeObject<TCacheItem>(itemString);
            }

            return item;
        }

        public async Task SetAsync<TCacheItem>(TCacheItem item, string cacheKey, TimeSpan duration)
        {
            var itemString = JsonConvert.SerializeObject(item);
            var database = _connectionMultiplexer.GetDatabase();
            await database.StringSetAsync(cacheKey, itemString, duration);
        }
    }
}