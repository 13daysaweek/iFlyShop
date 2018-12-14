using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThirteenDaysAWeek.iFlyShop.Api.Data.Repositories
{
    public interface IRepository<TModel>
    {
        Task<IEnumerable<TModel>> GetAll();

        Task<TModel> GetById(int id);
    }
}