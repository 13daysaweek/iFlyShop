using System;

namespace ThirteenDaysAWeek.iFlyShop.Api.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}