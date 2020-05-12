namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateServicesTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Services] ON
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (1, N'Ogólna diagnostyka ', 1, CAST(25.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (2, N'Ustawianie krzywizny gryfu ', 1, CAST(50.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (3, N'Regulacja gryfu', 1, CAST(25.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (4, N'Nacinanie siodełka', 1, CAST(50.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (5, N'Ustawienie menzury', 1, CAST(25.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (6, N'Ustawianie strun', 1, CAST(25.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (7, N'Szlifowanie progów', 1, CAST(300.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (8, N'Zmiana schematu połączenia elektroniki', 1, CAST(80.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (9, N'Ustawianie mostka', 1, CAST(40.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (10, N'Poprawa gniazda', 1, CAST(25.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (11, N'Polerowanie progów', 1, CAST(80.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (12, N'Konserwacja podstrunnicy ', 1, CAST(60.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (13, N'Konserwacja elektroniki ', 1, CAST(60.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (14, N'Ekranowanie elektroniki ', 1, CAST(200.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (15, N'Wymiana progów', 2, CAST(700.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (16, N'Wymiana strun', 2, CAST(20.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (17, N'Wymiana przetworników', 2, CAST(50.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (18, N'Wymiana kluczy', 2, CAST(40.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (19, N'Wymiana pickguardów', 2, CAST(40.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (20, N'Wymiana potencjometrów', 2, CAST(80.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (21, N'Wymiana gniazda', 2, CAST(30.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (22, N'Wymiana siodełka', 2, CAST(50.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (23, N'Wymiana przystawki', 2, CAST(45.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (24, N'Poprawki lakiernicze', 3, CAST(50.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (25, N'Poprawki ubytków materiału', 3, CAST(59.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (26, N'Ściąganie starej powłoki', 3, CAST(59.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (27, N'Lakierowanie', 3, CAST(50.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (28, N'Zmiana koloru', 3, CAST(50.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (29, N'Większe uszczerbki materiału', 4, CAST(50.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (30, N'Odbicia i wgniecenia', 4, CAST(50.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (31, N'Naprawa wyrwanego gniazda', 4, CAST(50.00 AS Decimal(18, 2)))
            INSERT INTO [dbo].[Services] ([ServiceId], [Name], [ServiceTypeId], [Price]) VALUES (32, N'Naprawa urwanych kluczy', 4, CAST(50.00 AS Decimal(18, 2)))
            SET IDENTITY_INSERT [dbo].[Services] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
