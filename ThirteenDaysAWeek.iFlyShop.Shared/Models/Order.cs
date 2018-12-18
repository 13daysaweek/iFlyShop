using System;
using System.Collections.Generic;

namespace ThirteenDaysAWeek.iFlyShop.Shared.Models
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderLineItem>();
        }

        public string OrderNumber { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public IList<OrderLineItem> Items { get; }
    }
}