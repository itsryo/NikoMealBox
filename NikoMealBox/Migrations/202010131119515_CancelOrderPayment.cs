namespace NikoMealBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CancelOrderPayment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Payment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Payment", c => c.String());
        }
    }
}
