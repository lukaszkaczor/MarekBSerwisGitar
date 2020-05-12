namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstrumentAndServicesTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instruments",
                c => new
                    {
                        InstrumentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InstrumentId);
            
            CreateTable(
                "dbo.InstrumentServices",
                c => new
                    {
                        InstrumentId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InstrumentId, t.ServiceId })
                .ForeignKey("dbo.Instruments", t => t.InstrumentId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.InstrumentId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.ServiceTypeId);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        ServiceTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.InstrumentServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.InstrumentServices", "InstrumentId", "dbo.Instruments");
            DropIndex("dbo.Services", new[] { "ServiceTypeId" });
            DropIndex("dbo.InstrumentServices", new[] { "ServiceId" });
            DropIndex("dbo.InstrumentServices", new[] { "InstrumentId" });
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.Services");
            DropTable("dbo.InstrumentServices");
            DropTable("dbo.Instruments");
        }
    }
}
