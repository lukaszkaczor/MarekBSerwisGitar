namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMainGalleryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainGalleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceGalleryId = c.Int(),
                        OurInstrumentsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.OurInstrumentsId)
                .ForeignKey("dbo.Galleries", t => t.ServiceGalleryId)
                .Index(t => t.ServiceGalleryId)
                .Index(t => t.OurInstrumentsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MainGalleries", "ServiceGalleryId", "dbo.Galleries");
            DropForeignKey("dbo.MainGalleries", "OurInstrumentsId", "dbo.Galleries");
            DropIndex("dbo.MainGalleries", new[] { "OurInstrumentsId" });
            DropIndex("dbo.MainGalleries", new[] { "ServiceGalleryId" });
            DropTable("dbo.MainGalleries");
        }
    }
}
