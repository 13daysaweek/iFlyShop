using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using ThirteenDaysAWeek.iFlyShop.Api.Data;
using ThirteenDaysAWeek.iFlyShop.Api.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IContextFactory _contextFactory;

        public ProductController(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        [Route("api/product")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<Product> products;

            using (var context = _contextFactory.CreateInstance())
            {
                products = await context.Products.ToListAsync();
            }

            return products;
        }

        [Route("api/product/{productId}")]
        [HttpGet]
        public async Task<Product> GetProductById(int productId)
        {
            Product product = null;

            using (var context = _contextFactory.CreateInstance())
            {
                product = await context.Products.FirstAsync(_ => _.ProductId == productId);
            }

            return product;
        }
    }
}
