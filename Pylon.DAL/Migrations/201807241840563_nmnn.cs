namespace Pylon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nmnn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "User_Id" });
            AddColumn("dbo.Products", "ProfileId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Products", "ProfileId");
            AddForeignKey("dbo.Products", "ProfileId", "dbo.Profiles", "Id");
            DropColumn("dbo.Products", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Products", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Products", new[] { "ProfileId" });
            DropColumn("dbo.Products", "ProfileId");
            CreateIndex("dbo.Products", "User_Id");
            AddForeignKey("dbo.Products", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
