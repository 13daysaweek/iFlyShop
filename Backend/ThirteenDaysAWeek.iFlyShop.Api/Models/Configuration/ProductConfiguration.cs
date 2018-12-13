using System.Data.Entity.ModelConfiguration;

namespace ThirteenDaysAWeek.iFlyShop.Api.Models.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(_ => _.ProductId);

            Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}