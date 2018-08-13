namespace Pylon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "ImageMimeType", c => c.String());
            AddColumn("dbo.Profiles", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "ImageData");
            DropColumn("dbo.Profiles", "ImageMimeType");
        }
    }
}
