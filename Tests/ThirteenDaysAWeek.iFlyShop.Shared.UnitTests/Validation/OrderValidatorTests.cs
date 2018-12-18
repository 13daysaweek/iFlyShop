using System;
using FluentAssertions;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;
using ThirteenDaysAWeek.iFlyShop.Shared.UnitTests.TheoryProviders;
using ThirteenDaysAWeek.iFlyShop.Shared.Validation;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Shared.UnitTests.Validation
{
    public class OrderValidatorTests
    {
        private readonly OrderValidator _validator = new OrderValidator();

        [Fact]
        public void Should_Be_Valid_When_Required_Values_Are_Present()
        {
            // Arrange
            var order = new Order { OrderDate = DateTime.Now, CustomerId = 1};
            order.Items.Add(GetValidOrderLineItem());

            // Act
            var result = _validator.Validate(order);

            // Assert
            result.IsValid
                .Should()
                .BeTrue();
        }

        [Theory]
        [ClassData(typeof(InvalidIntegerProvider))]
        public void Should_Not_Be_Valid_When_CustomerId_Is_Not_Valid(int customerId)
        {
            // Arrange
            var order = new Order {OrderDate = DateTime.Now, CustomerId = customerId};
            order.Items.Add(GetValidOrderLineItem());

            // Act
            var result = _validator.Validate(order);

            // Assert
            result.IsValid
                .Should()
                .BeFalse();
        }

        private OrderLineItem GetValidOrderLineItem()
        {
            return new OrderLineItem {ProductId = 1, Quantity = 1};
        }
    }
}
