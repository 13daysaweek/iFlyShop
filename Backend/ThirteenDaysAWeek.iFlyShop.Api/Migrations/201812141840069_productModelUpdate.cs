namespace ThirteenDaysAWeek.iFlyShop.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitPrice", c => c.Decimal(nullable: false, precision: 9, scale: 3));
            AddColumn("dbo.Products", "Cost", c => c.Decimal(nullable: false, precision: 9, scale: 3));
            AddColumn("dbo.Products", "ProductThumbnailImagePath", c => c.String(maxLength: 300));
            AddColumn("dbo.Products", "DateModified", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DateModified");
            DropColumn("dbo.Products", "ProductThumbnailImagePath");
            DropColumn("dbo.Products", "Cost");
            DropColumn("dbo.Products", "UnitPrice");
        }
    }
}
