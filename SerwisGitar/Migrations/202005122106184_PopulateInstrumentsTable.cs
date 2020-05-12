namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateInstrumentsTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[Instruments] ON
                INSERT INTO [dbo].[Instruments] ([InstrumentId], [Name]) VALUES (1, N'Gitara klasyczna')
                INSERT INTO [dbo].[Instruments] ([InstrumentId], [Name]) VALUES (2, N'Gitara akustyczna')
                INSERT INTO [dbo].[Instruments] ([InstrumentId], [Name]) VALUES (3, N'Gitara basowa')
                INSERT INTO [dbo].[Instruments] ([InstrumentId], [Name]) VALUES (4, N'Gitara elektryczna')
                SET IDENTITY_INSERT [dbo].[Instruments] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
