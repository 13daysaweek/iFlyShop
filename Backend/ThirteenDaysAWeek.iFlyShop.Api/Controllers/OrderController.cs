using System;
using System.Threading.Tasks;
using System.Web.Http;
using ThirteenDaysAWeek.iFlyShop.Api.Filters;
using ThirteenDaysAWeek.iFlyShop.Api.Models;
using ThirteenDaysAWeek.iFlyShop.Api.Services;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderPublisher _orderPublisher;

        public OrderController(IOrderPublisher orderPublisher)
        {
            _orderPublisher = orderPublisher ?? throw new ArgumentNullException(nameof(orderPublisher));
        }

        [HttpPost]
        [Route("api/order")]
        [ValidateModelState]
        public async Task<OrderCreateResponse> SubmitOrder(Order order)
        {
            order.OrderNumber = "test"; // Change
            order.OrderDate = DateTime.UtcNow;
            await _orderPublisher.SubmitOrderAsync(order);

            return new OrderCreateResponse {OrderNumber = order.OrderNumber};
        }
    }
}
