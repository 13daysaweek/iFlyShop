using System;
using FluentAssertions;
using Moq;
using ThirteenDaysAWeek.iFlyShop.Api.Data;
using ThirteenDaysAWeek.iFlyShop.Api.Data.Repositories;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests.Data.Repositories
{
    public class ProductRepositoryTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private readonly Mock<IContextFactory> _mockContextFactory;

        public ProductRepositoryTests()
        {
            _mockContextFactory = _mockRepository.Create<IContextFactory>();
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_ContextFactory_Is_Null()
        {
            // Arrange
            IContextFactory contextFactory = null;
            Action ctor = () => new ProductRepository(contextFactory);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_ContextFactory_Is_Not_Null()
        {
            // Arrange
            Action ctor = () => new ProductRepository(_mockContextFactory.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }
    }
}
