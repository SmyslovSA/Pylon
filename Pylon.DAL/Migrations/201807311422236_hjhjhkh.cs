namespace Pylon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hjhjhkh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "StartDate", c => c.String());
            AlterColumn("dbo.Orders", "EndDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
