namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlColumnToInsturmentsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instruments", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instruments", "ImageUrl");
        }
    }
}
