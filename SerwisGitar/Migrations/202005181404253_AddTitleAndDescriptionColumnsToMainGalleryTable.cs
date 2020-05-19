namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitleAndDescriptionColumnsToMainGalleryTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainGalleries", "Title", c => c.String());
            AddColumn("dbo.MainGalleries", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MainGalleries", "Description");
            DropColumn("dbo.MainGalleries", "Title");
        }
    }
}
