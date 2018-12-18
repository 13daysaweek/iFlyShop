using FluentValidation.Attributes;
using ThirteenDaysAWeek.iFlyShop.Shared.Validation;

namespace ThirteenDaysAWeek.iFlyShop.Shared.Models
{
    [Validator(typeof(OrderLineItemValidator))]
    public class OrderLineItem
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}