namespace Pylon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartNumber = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Maker = c.String(),
                        Image = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProfileID = c.Int(nullable: false),
                        Profile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Products", new[] { "Profile_Id" });
            DropTable("dbo.Products");
        }
    }
}
