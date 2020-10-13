namespace NikoMealBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddECpay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ECPays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MerchantTradeNo = c.String(),
                        MerchantTradeDate = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TradeDesc = c.String(),
                        ItemName = c.String(),
                        ChoosePayment = c.String(),
                        CheckMacValue = c.String(),
                        OrderRefId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreateUser = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        EditUser = c.String(),
                        EditTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ECPays");
        }
    }
}
