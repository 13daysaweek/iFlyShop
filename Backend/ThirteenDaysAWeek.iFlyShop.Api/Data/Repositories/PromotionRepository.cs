using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ThirteenDaysAWeek.iFlyShop.Api.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Data.Repositories
{
    public class PromotionRepository : IRepository<Promotion>
    {
        private readonly IContextFactory _contextFactory;

        public PromotionRepository(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public async Task<IEnumerable<Promotion>> GetAll()
        {
            var promotions = default(IEnumerable<Promotion>);

            using (var context = _contextFactory.CreateInstance())
            {
                promotions = await context.Promotions.ToListAsync();
            }

            return promotions;
        }

        public async Task<Promotion> GetById(int id)
        {
            var promotion = default(Promotion);

            using (var context = _contextFactory.CreateInstance())
            {
                promotion = await context.Promotions.FirstAsync(_ => _.PromotionId == id);
            }

            return promotion;
        }
    }
}