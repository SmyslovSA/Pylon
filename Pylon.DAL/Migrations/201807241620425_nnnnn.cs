namespace Pylon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nnnnn : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "Profile_Id" });
            DropColumn("dbo.Products", "ProfileID");
            RenameColumn(table: "dbo.Products", name: "Profile_Id", newName: "ProfileID");
            AlterColumn("dbo.Products", "ProfileID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Products", "ProfileID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "ProfileID" });
            AlterColumn("dbo.Products", "ProfileID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Products", name: "ProfileID", newName: "Profile_Id");
            AddColumn("dbo.Products", "ProfileID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Profile_Id");
        }
    }
}
