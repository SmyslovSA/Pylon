namespace Pylon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mmm : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "ProfileID", newName: "Profile_Id");
            RenameIndex(table: "dbo.Products", name: "IX_ProfileID", newName: "IX_Profile_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_Profile_Id", newName: "IX_ProfileID");
            RenameColumn(table: "dbo.Products", name: "Profile_Id", newName: "ProfileID");
        }
    }
}
