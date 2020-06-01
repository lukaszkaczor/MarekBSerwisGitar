namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactEmailTableToOrdersController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ContactEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ContactEmail");
        }
    }
}
