namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionColumnToOrderDetailsColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Description");
        }
    }
}
