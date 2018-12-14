namespace ThirteenDaysAWeek.iFlyShop.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productDateCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DateCreated", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DateCreated");
        }
    }
}
