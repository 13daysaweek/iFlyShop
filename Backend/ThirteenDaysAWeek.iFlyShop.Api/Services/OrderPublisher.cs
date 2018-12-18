using System;
using ThirteenDaysAWeek.iFlyShop.Api.Configuration;

namespace ThirteenDaysAWeek.iFlyShop.Api.Services
{
    public class OrderPublisher : IOrderPublisher
    {
        private readonly IAppConfiguration _configuration;

        public OrderPublisher(IAppConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
    }

    public interface IOrderPublisher
    {
    }
}