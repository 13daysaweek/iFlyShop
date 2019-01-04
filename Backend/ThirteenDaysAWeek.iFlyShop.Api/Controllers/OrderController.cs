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
        private readonly IOrderNumberService _orderNumberService;

        public OrderController(IOrderPublisher orderPublisher, IOrderNumberService orderNumberService)
        {
            _orderPublisher = orderPublisher ?? throw new ArgumentNullException(nameof(orderPublisher));
            _orderNumberService = orderNumberService ?? throw new ArgumentNullException(nameof(orderNumberService));
        }

        [HttpPost]
        [Route("api/order")]
        [ValidateModelState]
        public async Task<OrderCreateResponse> SubmitOrder(Order order)
        {
            order.OrderNumber = _orderNumberService.GetNewOrderNumber(8);
            order.OrderDate = DateTime.UtcNow;
            await _orderPublisher.SubmitOrderAsync(order);

            return new OrderCreateResponse {OrderNumber = order.OrderNumber};
        }
    }
}
