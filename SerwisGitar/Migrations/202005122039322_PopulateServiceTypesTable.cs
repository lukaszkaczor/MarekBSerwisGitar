namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateServiceTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[ServiceTypes] ON
                INSERT INTO [dbo].[ServiceTypes] ([ServiceTypeId], [Name]) VALUES (1, N'Serwis')
                INSERT INTO [dbo].[ServiceTypes] ([ServiceTypeId], [Name]) VALUES (2, N'Wymiana')
                INSERT INTO [dbo].[ServiceTypes] ([ServiceTypeId], [Name]) VALUES (3, N'Kosmetyka')
                INSERT INTO [dbo].[ServiceTypes] ([ServiceTypeId], [Name]) VALUES (4, N'Naprawa')
                SET IDENTITY_INSERT [dbo].[ServiceTypes] OFF
            ");
        }

        public override void Down()
        {
        }
    }
}
