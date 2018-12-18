using System;
using FluentAssertions;
using Moq;
using ThirteenDaysAWeek.iFlyShop.Api.Controllers;
using ThirteenDaysAWeek.iFlyShop.Api.Services;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests.Controllers
{
    public class OrderControllerTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private readonly Mock<IOrderPublisher> _mockOrderPublisher;

        public OrderControllerTests()
        {
            _mockOrderPublisher = _mockRepository.Create<IOrderPublisher>();
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_OrderPublisher_Is_Null()
        {
            // Arrange
            IOrderPublisher publisher = null;
            Action ctor = () => new OrderController(publisher);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_OrderPublisher_Is_Not_Null()
        {
            // Arrange
            Action ctor = () => new OrderController(_mockOrderPublisher.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }
    }
}
