namespace SerwisGitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdersAndOrderDetailsTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Decimal = c.Decimal(precision: 18, scale: 2),
                        ServiceId = c.Int(),
                        PartTypeId = c.Int(),
                        CustomInstrumentId = c.Int(),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailsId)
                .ForeignKey("dbo.CustomInstruments", t => t.CustomInstrumentId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: false)
                .ForeignKey("dbo.PartTypes", t => t.PartTypeId)
                .ForeignKey("dbo.Services", t => t.ServiceId)
                .Index(t => t.OrderId)
                .Index(t => t.ServiceId)
                .Index(t => t.PartTypeId)
                .Index(t => t.CustomInstrumentId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Message = c.String(),
                        PhoneNumber = c.String(),
                        OrderStatus = c.Int(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        EmployeeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.OrderDetailsOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        OrderDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.OrderDetailsId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetailsId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.OrderDetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.OrderDetails", "PartTypeId", "dbo.PartTypes");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetailsOrders", "OrderDetailsId", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetailsOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "CustomInstrumentId", "dbo.CustomInstruments");
            DropIndex("dbo.OrderDetailsOrders", new[] { "OrderDetailsId" });
            DropIndex("dbo.OrderDetailsOrders", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "ApplicationUserId" });
            DropIndex("dbo.OrderDetails", new[] { "CustomInstrumentId" });
            DropIndex("dbo.OrderDetails", new[] { "PartTypeId" });
            DropIndex("dbo.OrderDetails", new[] { "ServiceId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.OrderDetailsOrders");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
        }
    }
}
