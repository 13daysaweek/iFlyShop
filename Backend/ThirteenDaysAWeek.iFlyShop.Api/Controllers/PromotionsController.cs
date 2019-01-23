using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ThirteenDaysAWeek.iFlyShop.Api.Data.Repositories;
using ThirteenDaysAWeek.iFlyShop.Api.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Controllers
{
    public class PromotionsController : ApiController
    {
        private readonly IRepository<Promotion> _promotionRepository;

        public PromotionsController(IRepository<Promotion> promotionRepository)
        {
            _promotionRepository = promotionRepository ?? throw new ArgumentNullException(nameof(promotionRepository));
        }

        [HttpGet]
        [Route("api/promotion/")]
        public async Task<IEnumerable<Promotion>> Get()
        {
            var promo = await _promotionRepository.GetAll();

            return promo;
        }
    }
}
