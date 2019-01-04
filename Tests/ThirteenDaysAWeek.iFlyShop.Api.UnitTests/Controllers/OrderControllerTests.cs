using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using ThirteenDaysAWeek.iFlyShop.Api.Controllers;
using ThirteenDaysAWeek.iFlyShop.Api.Services;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests.Controllers
{
    public class OrderControllerTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private readonly Mock<IOrderPublisher> _mockOrderPublisher;
        private readonly Mock<IOrderNumberService> _mockOrderNumberService;
        private readonly Fixture _fixture = new Fixture();

        private readonly OrderController _controller;

        public OrderControllerTests()
        {
            _mockOrderPublisher = _mockRepository.Create<IOrderPublisher>();
            _mockOrderNumberService = _mockRepository.Create<IOrderNumberService>();

            _controller = new OrderController(_mockOrderPublisher.Object, _mockOrderNumberService.Object);
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_OrderPublisher_Is_Null()
        {
            // Arrange
            IOrderPublisher publisher = null;
            Action ctor = () => new OrderController(publisher, _mockOrderNumberService.Object);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_OrderPublisher_Is_Not_Null()
        {
            // Arrange
            Action ctor = () => new OrderController(_mockOrderPublisher.Object, _mockOrderNumberService.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_OrderNumberService_Is_Null()
        {
            // Arrange
            IOrderNumberService orderNumberService = null;
            Action ctor = () => new OrderController(_mockOrderPublisher.Object, orderNumberService);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_OrderNumberService_Is_Not_Null()
        {
            // Arrange
            Action ctor = () => new OrderController(_mockOrderPublisher.Object, _mockOrderNumberService.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task SubmitOrder_Should_Send_Order_To_Queue()
        {
            // Arrange
            var order = _fixture.Create<Order>();
            var orderNumber = _fixture.Create<string>();
            const int size = 8;

            _mockOrderPublisher.Setup(_ => _.SubmitOrderAsync(order))
                .Returns(Task.CompletedTask);

            _mockOrderNumberService.Setup(_ => _.GetNewOrderNumber(size))
                .Returns(orderNumber);

            // Act
            var result = await _controller.SubmitOrder(order);

            // Assert
            _mockRepository.VerifyAll();

            result.Should()
                .NotBeNull();

            result.OrderNumber
                .Should()
                .NotBeNullOrWhiteSpace();
        }
    }
}
