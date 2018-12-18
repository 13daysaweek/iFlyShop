using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ThirteenDaysAWeek.iFlyShop.Api.Filters;
using ThirteenDaysAWeek.iFlyShop.Api.Models;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Controllers
{
    public class OrderController : ApiController
    {
        [HttpPost]
        [Route("api/order")]
        [ValidateModelState]
        public HttpResponseMessage SubmitOrder(Order order)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new OrderCreateResponse {OrderNumber = "test"});
        }
    }
}
