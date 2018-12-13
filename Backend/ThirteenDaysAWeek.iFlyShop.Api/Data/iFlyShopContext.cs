using System.Data.Entity;

namespace ThirteenDaysAWeek.iFlyShop.Api.Data
{
    public class iFlyShopContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(typeof(iFlyShopContext).Assembly);
        }
    }

}