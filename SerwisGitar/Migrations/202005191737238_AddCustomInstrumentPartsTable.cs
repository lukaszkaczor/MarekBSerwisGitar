namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomInstrumentPartsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomInstrumentParts",
                c => new
                    {
                        CustomInstrumentId = c.Int(nullable: false),
                        GuitarPartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomInstrumentId, t.GuitarPartId })
                .ForeignKey("dbo.CustomInstruments", t => t.CustomInstrumentId, cascadeDelete: true)
                .ForeignKey("dbo.GuitarParts", t => t.GuitarPartId, cascadeDelete: true)
                .Index(t => t.CustomInstrumentId)
                .Index(t => t.GuitarPartId);
            
            CreateTable(
                "dbo.CustomInstruments",
                c => new
                    {
                        CustomInstrumentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PrimaryColor = c.String(),
                        SecondaryColor = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                        InstrumentId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomInstrumentId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Instruments", t => t.InstrumentId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.InstrumentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomInstrumentParts", "GuitarPartId", "dbo.GuitarParts");
            DropForeignKey("dbo.CustomInstruments", "InstrumentId", "dbo.Instruments");
            DropForeignKey("dbo.CustomInstrumentParts", "CustomInstrumentId", "dbo.CustomInstruments");
            DropForeignKey("dbo.CustomInstruments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.CustomInstruments", new[] { "InstrumentId" });
            DropIndex("dbo.CustomInstruments", new[] { "ApplicationUserId" });
            DropIndex("dbo.CustomInstrumentParts", new[] { "GuitarPartId" });
            DropIndex("dbo.CustomInstrumentParts", new[] { "CustomInstrumentId" });
            DropTable("dbo.CustomInstruments");
            DropTable("dbo.CustomInstrumentParts");
        }
    }
}
