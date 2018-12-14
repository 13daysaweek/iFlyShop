using System;
using FluentAssertions;
using Moq;
using ThirteenDaysAWeek.iFlyShop.Api.Caching;
using ThirteenDaysAWeek.iFlyShop.Api.Data;
using ThirteenDaysAWeek.iFlyShop.Api.Data.Repositories;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests.Data.Repositories
{
    public class ProductRepositoryTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private readonly Mock<IContextFactory> _mockContextFactory;
        private readonly Mock<ICacheAccessor> _mockCacheAccessor;

        public ProductRepositoryTests()
        {
            _mockContextFactory = _mockRepository.Create<IContextFactory>();
            _mockCacheAccessor = _mockRepository.Create<ICacheAccessor>();
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_ContextFactory_Is_Null()
        {
            // Arrange
            IContextFactory contextFactory = null;
            Action ctor = () => new ProductRepository(contextFactory, _mockCacheAccessor.Object);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_ContextFactory_Is_Not_Null()
        {
            // Arrange
            Action ctor = () => new ProductRepository(_mockContextFactory.Object, _mockCacheAccessor.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_CacheAccessor_Is_Null()
        {
            // Arrange
            ICacheAccessor caceAccessor = null;
            Action ctor = () => new ProductRepository(_mockContextFactory.Object, caceAccessor);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_CacheAccessor_Is_Not_Null()
        {
            // Arrange
            Action ctor = () => new ProductRepository(_mockContextFactory.Object, _mockCacheAccessor.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }
    }
}
