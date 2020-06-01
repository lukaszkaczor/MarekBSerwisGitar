namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomInstrumentIdToShoppingCartsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "InstrumentId", "dbo.Instruments");
            DropIndex("dbo.ShoppingCarts", new[] { "InstrumentId" });
            AddColumn("dbo.ShoppingCarts", "CustomInstrumentId", c => c.Int());
            AlterColumn("dbo.ShoppingCarts", "InstrumentId", c => c.Int());
            CreateIndex("dbo.ShoppingCarts", "InstrumentId");
            CreateIndex("dbo.ShoppingCarts", "CustomInstrumentId");
            AddForeignKey("dbo.ShoppingCarts", "CustomInstrumentId", "dbo.CustomInstruments", "CustomInstrumentId");
            AddForeignKey("dbo.ShoppingCarts", "InstrumentId", "dbo.Instruments", "InstrumentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "InstrumentId", "dbo.Instruments");
            DropForeignKey("dbo.ShoppingCarts", "CustomInstrumentId", "dbo.CustomInstruments");
            DropIndex("dbo.ShoppingCarts", new[] { "CustomInstrumentId" });
            DropIndex("dbo.ShoppingCarts", new[] { "InstrumentId" });
            AlterColumn("dbo.ShoppingCarts", "InstrumentId", c => c.Int(nullable: false));
            DropColumn("dbo.ShoppingCarts", "CustomInstrumentId");
            CreateIndex("dbo.ShoppingCarts", "InstrumentId");
            AddForeignKey("dbo.ShoppingCarts", "InstrumentId", "dbo.Instruments", "InstrumentId", cascadeDelete: true);
        }
    }
}
