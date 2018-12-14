using System;

namespace ThirteenDaysAWeek.iFlyShop.Api.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Cost { get; set; }

        public string ProductThumbnailImagePath { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }
    }
}