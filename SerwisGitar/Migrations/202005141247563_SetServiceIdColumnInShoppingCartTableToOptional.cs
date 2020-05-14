namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetServiceIdColumnInShoppingCartTableToOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "ServiceId", "dbo.Services");
            DropIndex("dbo.ShoppingCarts", new[] { "ServiceId" });
            AlterColumn("dbo.ShoppingCarts", "ServiceId", c => c.Int());
            CreateIndex("dbo.ShoppingCarts", "ServiceId");
            AddForeignKey("dbo.ShoppingCarts", "ServiceId", "dbo.Services", "ServiceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "ServiceId", "dbo.Services");
            DropIndex("dbo.ShoppingCarts", new[] { "ServiceId" });
            AlterColumn("dbo.ShoppingCarts", "ServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "ServiceId");
            AddForeignKey("dbo.ShoppingCarts", "ServiceId", "dbo.Services", "ServiceId", cascadeDelete: true);
        }
    }
}
