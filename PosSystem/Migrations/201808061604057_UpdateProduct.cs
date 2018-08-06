namespace PosSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDetails", "ProductMasterId", "dbo.ProductMasters");
            DropForeignKey("dbo.ProductPrices", "ProductDetailsId", "dbo.ProductDetails");
            DropIndex("dbo.ProductDetails", new[] { "ProductMasterId" });
            DropIndex("dbo.ProductPrices", new[] { "ProductDetailsId" });
            AddColumn("dbo.ProductMasters", "ProductDetailsId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductMasters", "ProductPriceId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductMasters", "ProductDetailsId");
            CreateIndex("dbo.ProductMasters", "ProductPriceId");
            AddForeignKey("dbo.ProductMasters", "ProductDetailsId", "dbo.ProductDetails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductMasters", "ProductPriceId", "dbo.ProductPrices", "Id", cascadeDelete: true);
            DropColumn("dbo.ProductDetails", "ProductMasterId");
            DropColumn("dbo.ProductPrices", "ProductDetailsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductPrices", "ProductDetailsId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDetails", "ProductMasterId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductMasters", "ProductPriceId", "dbo.ProductPrices");
            DropForeignKey("dbo.ProductMasters", "ProductDetailsId", "dbo.ProductDetails");
            DropIndex("dbo.ProductMasters", new[] { "ProductPriceId" });
            DropIndex("dbo.ProductMasters", new[] { "ProductDetailsId" });
            DropColumn("dbo.ProductMasters", "ProductPriceId");
            DropColumn("dbo.ProductMasters", "ProductDetailsId");
            CreateIndex("dbo.ProductPrices", "ProductDetailsId");
            CreateIndex("dbo.ProductDetails", "ProductMasterId");
            AddForeignKey("dbo.ProductPrices", "ProductDetailsId", "dbo.ProductDetails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductDetails", "ProductMasterId", "dbo.ProductMasters", "Id", cascadeDelete: true);
        }
    }
}
