using FluentAssertions;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;
using ThirteenDaysAWeek.iFlyShop.Shared.Validation;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Shared.UnitTests.Validation
{
    public class OrderLineItemValidatorTests
    {
        private readonly OrderLineItemValidator _validator = new OrderLineItemValidator();

        [Fact]
        public void Should_Be_Valid_When_ProductId_And_Quantity_Are_Greater_Than_Zero()
        {
            // Arrange
            var item = new OrderLineItem {ProductId = 1, Quantity = 1};

            // Act
            var result = _validator.Validate(item);

            // Assert
            result.IsValid
                .Should()
                .BeTrue();
        }
    }
}
