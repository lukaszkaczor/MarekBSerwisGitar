namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsturmentColumnToOrderDetailsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "InstrumentId", c => c.Int());
            CreateIndex("dbo.OrderDetails", "InstrumentId");
            AddForeignKey("dbo.OrderDetails", "InstrumentId", "dbo.Instruments", "InstrumentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "InstrumentId", "dbo.Instruments");
            DropIndex("dbo.OrderDetails", new[] { "InstrumentId" });
            DropColumn("dbo.OrderDetails", "InstrumentId");
        }
    }
}
