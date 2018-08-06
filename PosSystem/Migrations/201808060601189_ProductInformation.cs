namespace PosSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatagoryName = c.String(nullable: false, maxLength: 4000),
                        ProductDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductDetails", t => t.ProductDetailsId, cascadeDelete: true)
                .Index(t => t.ProductDetailsId);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                        SalePrice = c.Double(nullable: false),
                        StockEntryDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        ProductMasterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductMasters", t => t.ProductMasterId, cascadeDelete: true)
                .Index(t => t.ProductMasterId);
            
            CreateTable(
                "dbo.ProductMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false, maxLength: 255),
                        ItemCatagory = c.String(nullable: false, maxLength: 255),
                        Unit = c.String(nullable: false, maxLength: 64),
                        UnitValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemPrice = c.Int(nullable: false),
                        ProductDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductDetails", t => t.ProductDetailsId, cascadeDelete: true)
                .Index(t => t.ProductDetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPrices", "ProductDetailsId", "dbo.ProductDetails");
            DropForeignKey("dbo.ProductCatagories", "ProductDetailsId", "dbo.ProductDetails");
            DropForeignKey("dbo.ProductDetails", "ProductMasterId", "dbo.ProductMasters");
            DropIndex("dbo.ProductPrices", new[] { "ProductDetailsId" });
            DropIndex("dbo.ProductDetails", new[] { "ProductMasterId" });
            DropIndex("dbo.ProductCatagories", new[] { "ProductDetailsId" });
            DropTable("dbo.ProductPrices");
            DropTable("dbo.ProductMasters");
            DropTable("dbo.ProductDetails");
            DropTable("dbo.ProductCatagories");
        }
    }
}
