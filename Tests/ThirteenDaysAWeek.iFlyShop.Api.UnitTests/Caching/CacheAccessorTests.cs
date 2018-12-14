using System;
using AutoFixture;
using FluentAssertions;
using ThirteenDaysAWeek.iFlyShop.Api.Caching;
using ThirteenDaysAWeek.iFlyShop.Api.UnitTests.TheoryProviders;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests.Caching
{
    public class CacheAccessorTests
    {
        [Theory]
        [ClassData(typeof(NullAndEmptyStringProvider))]
        public void Constructor_Should_Throw_ArgumentException_When_ConnectionString_Is_Null_Or_Empty(string connectionString)
        {
            // Arrange
            Action ctor = () => new CacheAccessor(connectionString);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentException_When_ConnectionString_Is_Not_Null()
        {
            // Arrange
            var connectionString = new Fixture().Create<string>();
            Action ctor = () => new CacheAccessor(connectionString);

            // Assert
            ctor.Should()
                .NotThrow<ArgumentException>();
        }
    }
}
