namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedNameOfPriceInOrderDetailsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Price", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.OrderDetails", "Decimal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Decimal", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.OrderDetails", "Price");
        }
    }
}
