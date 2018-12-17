using System;
using AutoFixture;
using FluentAssertions;
using Moq;
using ThirteenDaysAWeek.iFlyShop.Api.Caching;
using ThirteenDaysAWeek.iFlyShop.Api.Telemetry;
using ThirteenDaysAWeek.iFlyShop.Api.UnitTests.TheoryProviders;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests.Caching
{
    public class CacheAccessorTests
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private readonly Mock<IDependencyTracker> _mockDependencyTracker;

        public CacheAccessorTests()
        {
            _mockDependencyTracker = _mockRepository.Create<IDependencyTracker>();
        }

        [Theory]
        [ClassData(typeof(NullAndEmptyStringProvider))]
        public void Constructor_Should_Throw_ArgumentException_When_ConnectionString_Is_Null_Or_Empty(string connectionString)
        {
            // Arrange
            Action ctor = () => new CacheAccessor(connectionString, _mockDependencyTracker.Object);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentException_When_ConnectionString_Is_Not_Null()
        {
            // Arrange
            var connectionString = _fixture.Create<string>();
            Action ctor = () => new CacheAccessor(connectionString, _mockDependencyTracker.Object);

            // Assert
            ctor.Should()
                .NotThrow<ArgumentException>();
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_IDependencyTracker_Is_Null()
        {
            // Arrange
            var connectionString = _fixture.Create<string>();
            IDependencyTracker dependencyTracker = null;
            Action ctor = () => new CacheAccessor(connectionString, dependencyTracker);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_IDependencyTracker_Is_Not_Null()
        {
            // Arrange
            var connectionString = _fixture.Create<string>();
            Action ctor = () => new CacheAccessor(connectionString, _mockDependencyTracker.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }
    }
}
