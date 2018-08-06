namespace PosSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductMasters", "ProductPriceId", "dbo.ProductPrices");
            DropIndex("dbo.ProductMasters", new[] { "ProductPriceId" });
            AddColumn("dbo.ProductDetails", "ProductPriceId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductMasters", "ProductCatagoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductDetails", "ProductPriceId");
            CreateIndex("dbo.ProductMasters", "ProductCatagoryId");
            AddForeignKey("dbo.ProductDetails", "ProductPriceId", "dbo.ProductPrices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductMasters", "ProductCatagoryId", "dbo.ProductCatagories", "Id", cascadeDelete: true);
            DropColumn("dbo.ProductMasters", "ItemCatagory");
            DropColumn("dbo.ProductMasters", "ProductPriceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductMasters", "ProductPriceId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductMasters", "ItemCatagory", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.ProductMasters", "ProductCatagoryId", "dbo.ProductCatagories");
            DropForeignKey("dbo.ProductDetails", "ProductPriceId", "dbo.ProductPrices");
            DropIndex("dbo.ProductMasters", new[] { "ProductCatagoryId" });
            DropIndex("dbo.ProductDetails", new[] { "ProductPriceId" });
            DropColumn("dbo.ProductMasters", "ProductCatagoryId");
            DropColumn("dbo.ProductDetails", "ProductPriceId");
            CreateIndex("dbo.ProductMasters", "ProductPriceId");
            AddForeignKey("dbo.ProductMasters", "ProductPriceId", "dbo.ProductPrices", "Id", cascadeDelete: true);
        }
    }
}
