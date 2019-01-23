namespace ThirteenDaysAWeek.iFlyShop.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Promotions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 3000),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Promotions");
        }
    }
}
