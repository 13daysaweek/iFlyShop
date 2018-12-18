using FluentValidation;
using ThirteenDaysAWeek.iFlyShop.Shared.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Validation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(_ => _.CustomerId)
                .GreaterThan(0)
                .WithMessage(Strings.OrderValidator_CustomerId_Must_Be_Greater_Than_Zero);

            RuleFor(_ => _.Items)
                .NotEmpty()
                .WithMessage(Strings.OrderValidator_Items_Must_Not_Be_Empty);

            RuleForEach(_ => _.Items)
                .SetValidator(new OrderLineItemValidator());
        }
    }
}