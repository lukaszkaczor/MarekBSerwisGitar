namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoppingCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        ServiceId = c.Int(nullable: false),
                        ServiceDescription = c.String(),
                    })
                .PrimaryKey(t => t.ShoppingCartId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ShoppingCarts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "ServiceId" });
            DropIndex("dbo.ShoppingCarts", new[] { "ApplicationUserId" });
            DropTable("dbo.ShoppingCarts");
        }
    }
}
