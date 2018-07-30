namespace Pylon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageProducts",
                c => new
                    {
                        Image_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Image_Id, t.Product_Id })
                .ForeignKey("dbo.Images", t => t.Image_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Image_Id)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.Profiles", "Phone", c => c.String());
            AddColumn("dbo.Profiles", "CompanyName", c => c.String());
            DropColumn("dbo.Products", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Image", c => c.String());
            DropForeignKey("dbo.ImageProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ImageProducts", "Image_Id", "dbo.Images");
            DropIndex("dbo.ImageProducts", new[] { "Product_Id" });
            DropIndex("dbo.ImageProducts", new[] { "Image_Id" });
            DropColumn("dbo.Profiles", "CompanyName");
            DropColumn("dbo.Profiles", "Phone");
            DropTable("dbo.ImageProducts");
            DropTable("dbo.Images");
        }
    }
}
