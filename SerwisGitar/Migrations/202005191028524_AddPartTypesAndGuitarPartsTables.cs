namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPartTypesAndGuitarPartsTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuitarParts",
                c => new
                    {
                        GuitarPartId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PartTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GuitarPartId)
                .ForeignKey("dbo.PartTypes", t => t.PartTypeId, cascadeDelete: true)
                .Index(t => t.PartTypeId);
            
            CreateTable(
                "dbo.PartTypes",
                c => new
                    {
                        PartTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PartTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GuitarParts", "PartTypeId", "dbo.PartTypes");
            DropIndex("dbo.GuitarParts", new[] { "PartTypeId" });
            DropTable("dbo.PartTypes");
            DropTable("dbo.GuitarParts");
        }
    }
}
