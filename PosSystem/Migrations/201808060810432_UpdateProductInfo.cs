namespace PosSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductInfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCatagories", "ProductDetailsId", "dbo.ProductDetails");
            DropIndex("dbo.ProductCatagories", new[] { "ProductDetailsId" });
            AddColumn("dbo.ProductPrices", "InsertDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProductCatagories", "ProductDetailsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCatagories", "ProductDetailsId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductPrices", "InsertDate");
            CreateIndex("dbo.ProductCatagories", "ProductDetailsId");
            AddForeignKey("dbo.ProductCatagories", "ProductDetailsId", "dbo.ProductDetails", "Id", cascadeDelete: true);
        }
    }
}
