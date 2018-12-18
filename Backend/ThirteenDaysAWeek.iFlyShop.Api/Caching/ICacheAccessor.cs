using System;
using System.Threading.Tasks;

namespace ThirteenDaysAWeek.iFlyShop.Api.Caching
{
    public interface ICacheAccessor
    {
        Task<TCacheItem> GetAsync<TCacheItem>(string cacheKey);

        Task<bool> SetAsync<TCacheItem>(TCacheItem item, string cacheKey, TimeSpan duration);
    }
}