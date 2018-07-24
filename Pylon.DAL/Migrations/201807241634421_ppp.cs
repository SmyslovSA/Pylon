namespace Pylon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ppp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Products", new[] { "Profile_Id" });
            DropColumn("dbo.Products", "Profile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Profile_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Products", "Profile_Id");
            AddForeignKey("dbo.Products", "Profile_Id", "dbo.Profiles", "Id");
        }
    }
}
