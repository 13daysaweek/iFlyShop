using System;
using FluentAssertions;
using Moq;
using ThirteenDaysAWeek.iFlyShop.Api.Configuration;
using ThirteenDaysAWeek.iFlyShop.Api.Services;
using ThirteenDaysAWeek.iFlyShop.Api.Telemetry;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests.Services
{
    public class OrderPublisherTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private readonly Mock<IAppConfiguration> _mockAppConfiguration;
        private readonly Mock<ITelemetryService> _mockTelemetryService;

        public OrderPublisherTests()
        {
            _mockAppConfiguration = _mockRepository.Create<IAppConfiguration>();
            _mockTelemetryService = _mockRepository.Create<ITelemetryService>();
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_AppConfiguration_Is_Null()
        {
            // Arrange
            IAppConfiguration configuration = null;
            Action ctor = () => new OrderPublisher(configuration, _mockTelemetryService.Object);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_AppConfiguration_Is_Not_Null()
        {
            // Arrange
            Action ctor = () => new OrderPublisher(_mockAppConfiguration.Object, _mockTelemetryService.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_TelemetryService_Is_Null()
        {
            // Arrange
            ITelemetryService telemetryService = null;
            Action ctor = () => new OrderPublisher(_mockAppConfiguration.Object, telemetryService);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_TelemetryService_Is_Not_Null()
        {
            // Arrange
            Action ctor = () => new OrderPublisher(_mockAppConfiguration.Object, _mockTelemetryService.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }
    }
}
