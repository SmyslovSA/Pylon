namespace Pylon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hccbccc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageProducts", "Image_Id", "dbo.Images");
            DropForeignKey("dbo.ImageProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.ImageProducts", new[] { "Image_Id" });
            DropIndex("dbo.ImageProducts", new[] { "Product_Id" });
            AddColumn("dbo.Orders", "ProfileId", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ProfileId");
            CreateIndex("dbo.Orders", "ProductId");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ProfileId", "dbo.Profiles", "Id");
            DropColumn("dbo.Orders", "Count");
            DropTable("dbo.Images");
            DropTable("dbo.ImageProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageProducts",
                c => new
                    {
                        Image_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Image_Id, t.Product_Id });
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Count", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "ProfileId" });
            DropColumn("dbo.Orders", "ProductId");
            DropColumn("dbo.Orders", "ProfileId");
            CreateIndex("dbo.ImageProducts", "Product_Id");
            CreateIndex("dbo.ImageProducts", "Image_Id");
            AddForeignKey("dbo.ImageProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImageProducts", "Image_Id", "dbo.Images", "Id", cascadeDelete: true);
        }
    }
}
