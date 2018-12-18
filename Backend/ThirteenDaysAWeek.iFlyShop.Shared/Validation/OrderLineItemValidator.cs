using FluentValidation;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;

namespace ThirteenDaysAWeek.iFlyShop.Shared.Validation
{
    public class OrderLineItemValidator : AbstractValidator<OrderLineItem>
    {
        public OrderLineItemValidator()
        {
            RuleFor(_ => _.ProductId)
                .GreaterThan(0)
                .WithMessage(ValidationMessages.OrderLineItemValidator_ProductId_Must_Be_Greater_Than_Zero);

            RuleFor(_ => _.Quantity)
                .GreaterThan(0)
                .WithMessage(ValidationMessages.OrderLineItemValidator_Quantity_Must_Be_Greater_Than_Zero);
        }
    }
}