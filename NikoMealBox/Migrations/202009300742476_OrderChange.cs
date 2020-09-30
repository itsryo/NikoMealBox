namespace NikoMealBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderStatusRefId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderStatus_Id", c => c.Int());
            CreateIndex("dbo.Orders", "OrderStatus_Id");
            AddForeignKey("dbo.Orders", "OrderStatus_Id", "dbo.OrderStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderStatus_Id", "dbo.OrderStatus");
            DropIndex("dbo.Orders", new[] { "OrderStatus_Id" });
            DropColumn("dbo.Orders", "OrderStatus_Id");
            DropColumn("dbo.Orders", "OrderStatusRefId");
        }
    }
}
