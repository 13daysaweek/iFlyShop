using System;
using FluentAssertions;
using Moq;
using ThirteenDaysAWeek.iFlyShop.Api.Configuration;
using ThirteenDaysAWeek.iFlyShop.Api.Services;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests.Services
{
    public class OrderPublisherTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private readonly Mock<IAppConfiguration> _mockAppConfiguration;

        public OrderPublisherTests()
        {
            _mockAppConfiguration = _mockRepository.Create<IAppConfiguration>();
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_AppConfiguration_Is_Null()
        {
            // Arrange
            IAppConfiguration configuration = null;
            Action ctor = () => new OrderPublisher(configuration);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_AppConfiguration_Is_Not_Null()
        {
            // Arrange
            Action ctor = () => new OrderPublisher(_mockAppConfiguration.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }
    }
}
