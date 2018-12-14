using ThirteenDaysAWeek.iFlyShop.Api.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.iFlyShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ThirteenDaysAWeek.iFlyShop.Api.Data.iFlyShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Products.AddOrUpdate(_ => _.ProductId,
                new Product { ProductId = 1, Name = "#18 Blue Wing Olive", UnitPrice = 2.99m, Cost = .99m, ProductThumbnailImagePath = "bwo.png" },
                new Product { ProductId = 2, Name = "#10 Black Wolly Bugger", UnitPrice = 3.50m, Cost = 1.25m, ProductThumbnailImagePath = "bwb.png" },
                new Product { ProductId = 3, Name = "#14 Prince Nymph", UnitPrice = 1.89m, Cost = 1.00m, ProductThumbnailImagePath = "pn.png" });
        }
    }
}
