using System;
using FluentAssertions;
using Moq;
using ThirteenDaysAWeek.iFlyShop.Api.Controllers;
using ThirteenDaysAWeek.iFlyShop.Api.Data;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests.Controllers
{
    public class ProductControllerTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private readonly Mock<IContextFactory> _mockContextFactory;

        public ProductControllerTests()
        {
            _mockContextFactory = _mockRepository.Create<IContextFactory>();
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_ContextFactory_Is_Null()
        {
            // Arrange
            IContextFactory contextFactory = null;
            Action ctor = () => new ProductController(contextFactory);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_ContextFactory_Is_Not_Null()
        {
            // Arrange
            Action ctor = () => new ProductController(_mockContextFactory.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }
    }
}
