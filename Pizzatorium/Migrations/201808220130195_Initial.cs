namespace Pizzatorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        dArea = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.AreaId);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false, identity: true),
                        dName = c.String(nullable: false, maxLength: 30),
                        dArea = c.String(nullable: false, maxLength: 25),
                        dPhoto = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        dIngredient = c.String(nullable: false, maxLength: 25),
                        dPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        dName = c.String(nullable: false, maxLength: 30),
                        dUserName = c.String(nullable: false, maxLength: 30),
                        dPassword = c.String(nullable: false, maxLength: 15),
                        dAddress = c.String(nullable: false, maxLength: 50),
                        dPhone = c.String(nullable: false, maxLength: 10),
                        dFavPizza = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Areas");
        }
    }
}
