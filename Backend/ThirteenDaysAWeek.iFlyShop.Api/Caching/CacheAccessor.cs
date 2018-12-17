using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;
using ThirteenDaysAWeek.iFlyShop.Api.Telemetry;

namespace ThirteenDaysAWeek.iFlyShop.Api.Caching
{
    public class CacheAccessor : ICacheAccessor
    {
        private readonly IDependencyTracker _dependencyTracker;
        private readonly string _redisHost;

        private readonly Lazy<ConnectionMultiplexer> _connectionMultiplexer = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_connectionString));
        private static string _connectionString;

        private const string CACHE_DEPENDENCY_TYPE = "Redis";

        public CacheAccessor(string cacheConnectionString, IDependencyTracker dependencyTracker)
        {
            if (string.IsNullOrWhiteSpace(cacheConnectionString))
            {
                throw new ArgumentException(Strings.CacheAccessor_Empty_ConnectionString_Message, nameof(cacheConnectionString));
            }

            _connectionString = cacheConnectionString;
            _dependencyTracker = dependencyTracker ?? throw new ArgumentNullException(nameof(dependencyTracker));
        }

        public async Task<TCacheItem> GetAsync<TCacheItem>(string cacheKey)
        {
            var item = default(TCacheItem);
            var database = _connectionMultiplexer.Value.GetDatabase();

            async Task<string> StringGet() => await database.StringGetAsync(cacheKey);

            var cacheItemString =
                await _dependencyTracker.TrackDependencyAsync((Func<Task<string>>) StringGet, _redisHost, CACHE_DEPENDENCY_TYPE,
                    "StringGetAsync", $"GET:{cacheKey}");

            if (!string.IsNullOrWhiteSpace(cacheItemString))
            {
                item = JsonConvert.DeserializeObject<TCacheItem>(cacheItemString);
            }

            return item;
        }

        public async Task<bool> SetAsync<TCacheItem>(TCacheItem item, string cacheKey, TimeSpan duration)
        {
            var database = _connectionMultiplexer.Value.GetDatabase();
            var itemString = JsonConvert.SerializeObject(item);

            var result = await _dependencyTracker.TrackDependencyAsync(() => database.StringSetAsync(cacheKey, itemString, duration), _redisHost,
                CACHE_DEPENDENCY_TYPE, "StringSetAsync", $"SET:{cacheKey}");

            return result;
        }
    }
}