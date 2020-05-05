namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagesAndGalleriesTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GalleryId);
            
            CreateTable(
                "dbo.ImageGalleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        Order = c.Int(),
                    })
                .PrimaryKey(t => new { t.GalleryId, t.ImageId })
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.GalleryId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageGalleries", "ImageId", "dbo.Images");
            DropForeignKey("dbo.ImageGalleries", "GalleryId", "dbo.Galleries");
            DropIndex("dbo.ImageGalleries", new[] { "ImageId" });
            DropIndex("dbo.ImageGalleries", new[] { "GalleryId" });
            DropTable("dbo.Images");
            DropTable("dbo.ImageGalleries");
            DropTable("dbo.Galleries");
        }
    }
}
