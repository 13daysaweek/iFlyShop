using System.Data.Entity.ModelConfiguration;
using System.Runtime.InteropServices;

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

            Property(_ => _.UnitPrice)
                .HasPrecision(9, 3)
                .IsRequired();

            Property(_ => _.Cost)
                .HasPrecision(9, 3)
                .IsRequired();

            Property(_ => _.ProductThumbnailImagePath)
                .HasMaxLength(300)
                .IsOptional();

            Property(_ => _.DateModified)
                .IsRequired();
        }
    }
}