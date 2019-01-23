﻿using System.Data.Entity;
using ThirteenDaysAWeek.iFlyShop.Api.Models;

namespace ThirteenDaysAWeek.iFlyShop.Api.Data
{
    public class iFlyShopContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(typeof(iFlyShopContext).Assembly);
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Promotion> Promotions { get; set; }
    }

}