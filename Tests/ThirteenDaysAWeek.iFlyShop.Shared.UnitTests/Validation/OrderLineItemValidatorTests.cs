using FluentAssertions;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;
using ThirteenDaysAWeek.iFlyShop.Shared.UnitTests.TheoryProviders;
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

        [Theory]
        [ClassData(typeof(InvalidIntegerProvider))]
        public void Should_Not_Be_Valid_When_ProductId_Is_Zero(int productId)
        {
            // Arrange
            var item = new OrderLineItem {ProductId = productId, Quantity = 1};

            // Act
            var result = _validator.Validate(item);

            // Assert
            result.IsValid
                .Should()
                .BeFalse();

            result.Errors.Count
                .Should()
                .Be(1);

            result.Errors[0].ErrorMessage
                .Should()
                .Be(ValidationMessages.OrderLineItemValidator_ProductId_Must_Be_Greater_Than_Zero);
        }

        [Theory]
        [ClassData(typeof(InvalidIntegerProvider))]
        public void Should_Not_Be_Valid_When_Quantity_Is_Zero(int quantity)
        {
            // Arrange
            var item = new OrderLineItem { ProductId = 1, Quantity = quantity };

            // Act
            var result = _validator.Validate(item);

            // Assert
            result.IsValid
                .Should()
                .BeFalse();

            result.Errors.Count
                .Should()
                .Be(1);

            result.Errors[0].ErrorMessage
                .Should()
                .Be(ValidationMessages.OrderLineItemValidator_Quantity_Must_Be_Greater_Than_Zero);
        }
    }
}
