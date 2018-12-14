using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ThirteenDaysAWeek.iFlyShop.Api.Caching;
using ThirteenDaysAWeek.iFlyShop.Api.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly IContextFactory _contextFactory;
        private readonly ICacheAccessor _cacheAccessor;

        private const int CACHE_SECONDS = 30;

        public ProductRepository(IContextFactory contextFactory, ICacheAccessor cacheAccessor)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            _cacheAccessor = cacheAccessor ?? throw new ArgumentNullException(nameof(cacheAccessor));
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var cacheKey = $"{nameof(Product)}:{nameof(GetAll)}";
            var models = await _cacheAccessor.GetAsync<IEnumerable<Product>>(cacheKey);

            if (models == null)
            {
                using (var context = _contextFactory.CreateInstance())
                {
                    models = await context.Products
                        .ToListAsync();
                }

                await _cacheAccessor.SetAsync(models, cacheKey, TimeSpan.FromSeconds(CACHE_SECONDS));
            }

            return models;
        }

        public async Task<Product> GetById(int id)
        {
            var cacheKey = $"{nameof(Product)}:{nameof(GetById)}:{id}";
            var product = await _cacheAccessor.GetAsync<Product>(cacheKey);

            if (product == null)
            {
                using (var context = _contextFactory.CreateInstance())
                {
                    product = await context.Products.FirstOrDefaultAsync(_ => _.ProductId == id);
                }

                await _cacheAccessor.SetAsync(product, cacheKey, TimeSpan.FromSeconds(CACHE_SECONDS));
            }

            return product;
        }
    }
}