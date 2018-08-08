namespace Pylon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileIsBlockProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "IsBlocked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "IsBlocked");
        }
    }
}
