namespace NikoMealBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuserId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Mobile", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Mobile", c => c.Int(nullable: false));
        }
    }
}
