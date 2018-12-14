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

        public ProductRepository(IContextFactory contextFactory, ICacheAccessor cacheAccessor)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            _cacheAccessor = cacheAccessor ?? throw new ArgumentNullException(nameof(cacheAccessor));
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var models = default(IEnumerable<Product>);

            using (var context = _contextFactory.CreateInstance())
            {
                models = await context.Products
                    .ToListAsync();
            }

            return models;
        }

        public async Task<Product> GetById(int id)
        {
            var product = default(Product);

            using (var context = _contextFactory.CreateInstance())
            {
                product = await context.Products.FirstOrDefaultAsync(_ => _.ProductId == id);
            }

            return product;
        }
    }
}