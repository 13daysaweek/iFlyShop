using System.Data.Entity.ModelConfiguration;

namespace ThirteenDaysAWeek.iFlyShop.Api.Models.Configuration
{
    public class PromotionConfiguration : EntityTypeConfiguration<Promotion>
    {
        public PromotionConfiguration()
        {
            HasKey(_ => _.PromotionId);

            Property(_ => _.Description)
                .HasMaxLength(3000)
                .IsRequired();

            Property(_ => _.StartDate)
                .IsRequired();

            Property(_ => _.EndDate)
                .IsRequired();
        }
    }
}