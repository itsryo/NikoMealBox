namespace NikoMealBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pdateRegisterForm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Height", x => x.String());
            AddColumn("dbo.AspNetUsers", "Weight", x => x.String());

        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Height");
            DropColumn("dbo.AspNetUsers", "Weight");
        }
    }
}
