namespace ThirteenDaysAWeek.iFlyShop.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productDefaultValueUpdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateModified", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
            AlterColumn("dbo.Products", "DateCreated", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "DateModified", c => c.DateTime(nullable: false));
        }
    }
}
