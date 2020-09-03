namespace NikoMealBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFormTest01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", x => x.String());
            AddColumn("dbo.AspNetUsers", "Mobile", x => x.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "Mobile");
        }
    }
}
