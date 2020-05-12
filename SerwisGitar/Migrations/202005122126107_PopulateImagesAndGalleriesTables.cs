namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateImagesAndGalleriesTables : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT [dbo].[Images] ON
                INSERT INTO [dbo].[Images] ([ImageId], [Name], [Url]) VALUES (1, N'1', N'https://www.ecopetit.cat/wpic/mpic/5-57255_ultra-hd-guitar-wallpaper-hd.jpg')
                INSERT INTO [dbo].[Images] ([ImageId], [Name], [Url]) VALUES (2, N'2', N'https://images.wallpaperscraft.com/image/guitar_close-up_house_80963_1280x720.jpg')
                INSERT INTO [dbo].[Images] ([ImageId], [Name], [Url]) VALUES (3, N'3', N'https://lh4.googleusercontent.com/proxy/Vx0sztzOGJGUxtWxu5mKjvTZSW2sJCXdUQXw9MwXRVTocODPVrWEEEjSDjtexdKdehvhYI_j9LKpEYoFIUt1f6ggy0FZAxc')
                INSERT INTO [dbo].[Images] ([ImageId], [Name], [Url]) VALUES (4, N'4', N'https://images.wallpaperscraft.com/image/guitarist_guitar_musical_instrument_124648_1280x720.jpg')
                INSERT INTO [dbo].[Images] ([ImageId], [Name], [Url]) VALUES (5, N'1', N'https://lh3.googleusercontent.com/proxy/pRyYWHE_TXozwEkA9Rx8ZESVyTxcsVsL_lykp3DeTNaZ2oYT3wKfv9jY8-MQd-_2UsnU8-rpfyRNZifSSagUyTgeOstFubE')
                INSERT INTO [dbo].[Images] ([ImageId], [Name], [Url]) VALUES (6, N'2', N'https://c4.wallpaperflare.com/wallpaper/60/100/24/music-guitar-wallpaper-preview.jpg')
                INSERT INTO [dbo].[Images] ([ImageId], [Name], [Url]) VALUES (7, N'3', N'https://wallpapertag.com/wallpaper/middle/e/b/0/333709-guitar-wallpaper-2560x1440-720p.jpg')
                INSERT INTO [dbo].[Images] ([ImageId], [Name], [Url]) VALUES (8, N'4', N'https://www.wallpaperbetter.com/wallpaper/644/617/93/guitar-hd-720P-wallpaper-middle-size.jpg')
                INSERT INTO [dbo].[Images] ([ImageId], [Name], [Url]) VALUES (9, N'5', N'https://c4.wallpaperflare.com/wallpaper/730/825/285/black-guitar-wallpaper-preview.jpg')
                SET IDENTITY_INSERT [dbo].[Images] OFF
");


            Sql(@"
                SET IDENTITY_INSERT [dbo].[Galleries] ON
            INSERT INTO [dbo].[Galleries] ([GalleryId], [Name]) VALUES (1, N'Serwis')
            INSERT INTO [dbo].[Galleries] ([GalleryId], [Name]) VALUES (2, N'gitary personalizowane')
            SET IDENTITY_INSERT [dbo].[Galleries] OFF
");

            Sql(@"
                INSERT INTO [dbo].[ImageGalleries] ([GalleryId], [ImageId], [Order]) VALUES (1, 1, 1)
            INSERT INTO [dbo].[ImageGalleries] ([GalleryId], [ImageId], [Order]) VALUES (1, 2, 2)
            INSERT INTO [dbo].[ImageGalleries] ([GalleryId], [ImageId], [Order]) VALUES (1, 3, 3)
            INSERT INTO [dbo].[ImageGalleries] ([GalleryId], [ImageId], [Order]) VALUES (1, 4, 4)
            INSERT INTO [dbo].[ImageGalleries] ([GalleryId], [ImageId], [Order]) VALUES (2, 5, 1)
            INSERT INTO [dbo].[ImageGalleries] ([GalleryId], [ImageId], [Order]) VALUES (2, 6, 2)
            INSERT INTO [dbo].[ImageGalleries] ([GalleryId], [ImageId], [Order]) VALUES (2, 7, 3)
            INSERT INTO [dbo].[ImageGalleries] ([GalleryId], [ImageId], [Order]) VALUES (2, 8, 4)
            INSERT INTO [dbo].[ImageGalleries] ([GalleryId], [ImageId], [Order]) VALUES (2, 9, 5)
");

            Sql(@"
SET IDENTITY_INSERT [dbo].[MainGalleries] ON
INSERT INTO [dbo].[MainGalleries] ([Id], [ServiceGalleryId], [OurInstrumentsId]) VALUES (1, 1, 2)
SET IDENTITY_INSERT [dbo].[MainGalleries] OFF

");

        }
        
        public override void Down()
        {
        }
    }
}
