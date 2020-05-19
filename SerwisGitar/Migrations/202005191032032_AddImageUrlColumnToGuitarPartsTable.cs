namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlColumnToGuitarPartsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GuitarParts", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GuitarParts", "ImageUrl");
        }
    }
}
