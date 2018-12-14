using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ThirteenDaysAWeek.iFlyShop.Api.Data.Repositories;
using ThirteenDaysAWeek.iFlyShop.Api.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IRepository<Product> _productRepository;

        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [Route("api/product")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _productRepository.GetAll();

            return products;
        }

        [Route("api/product/{productId}")]
        [HttpGet]
        public async Task<Product> GetProductById(int productId)
        {
            var product = await _productRepository.GetById(productId);

            return product;
        }
    }
}
