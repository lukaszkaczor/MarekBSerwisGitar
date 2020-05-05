namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"  
               INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3d35a60d-f524-4706-8db5-7407a7ccec11', N'admin@sklepgitar.pl', 0, N'ANu5fkG5Q66JowXj50P47GMZAV0aY5n/4jjfev4/CjhAwcr9L2TzVE0E3mhXXpttVg==', N'ee8e9895-f4dc-48d1-aee9-3fae3d3c4907', NULL, 0, 0, NULL, 1, 0, N'admin@serwisgitar.pl')
               INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'be54a320-81ab-41d3-a035-52c5283c3236', N'Admin')
               INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3d35a60d-f524-4706-8db5-7407a7ccec11', N'be54a320-81ab-41d3-a035-52c5283c3236')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
