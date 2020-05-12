namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstrumentColumnToShoppingCartTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "InstrumentId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "InstrumentId");
            AddForeignKey("dbo.ShoppingCarts", "InstrumentId", "dbo.Instruments", "InstrumentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "InstrumentId", "dbo.Instruments");
            DropIndex("dbo.ShoppingCarts", new[] { "InstrumentId" });
            DropColumn("dbo.ShoppingCarts", "InstrumentId");
        }
    }
}
