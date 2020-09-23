namespace NikoMealBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderModify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "OrdersId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "ProductsId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ContactMail", c => c.String());
            AddColumn("dbo.Orders", "Remark", c => c.String());
            AddColumn("dbo.Orders", "Payment", c => c.String());
            AddColumn("dbo.Orders", "UserRefId", c => c.String(maxLength: 128));
            CreateIndex("dbo.OrderDetails", "OrdersId");
            CreateIndex("dbo.OrderDetails", "ProductsId");
            CreateIndex("dbo.Orders", "UserRefId");
            AddForeignKey("dbo.Orders", "UserRefId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.OrderDetails", "OrdersId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "ProductsId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.OrderDetails", "ProductId");
            DropColumn("dbo.OrderDetails", "OrderId");
            DropColumn("dbo.OrderDetails", "UnitPrice");
            DropColumn("dbo.Orders", "OrderStatusId");
            DropColumn("dbo.Orders", "TelephoneExtension");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TelephoneExtension", c => c.String(maxLength: 8));
            AddColumn("dbo.Orders", "OrderStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderDetails", "ProductsId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrdersId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserRefId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "UserRefId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductsId" });
            DropIndex("dbo.OrderDetails", new[] { "OrdersId" });
            DropColumn("dbo.Orders", "UserRefId");
            DropColumn("dbo.Orders", "Payment");
            DropColumn("dbo.Orders", "Remark");
            DropColumn("dbo.Orders", "ContactMail");
            DropColumn("dbo.OrderDetails", "ProductsId");
            DropColumn("dbo.OrderDetails", "OrdersId");
        }
    }
}
