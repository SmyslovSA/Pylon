namespace Pylon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileIsDeletedProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "IsDeleted");
        }
    }
}
