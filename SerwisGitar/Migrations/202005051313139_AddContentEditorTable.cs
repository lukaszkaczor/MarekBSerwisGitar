namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContentEditorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentEditors",
                c => new
                    {
                        ContentEditorId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Page = c.Int(nullable: false),
                        IsDraftVersion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContentEditorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContentEditors");
        }
    }
}
