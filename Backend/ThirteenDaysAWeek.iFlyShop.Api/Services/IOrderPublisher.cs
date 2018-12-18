using System.Threading.Tasks;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Services
{
    public interface IOrderPublisher
    {
        Task SubmitOrderAsync(Order order);
    }
}