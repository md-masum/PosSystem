namespace PosSystem.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public DbSet<ProductMaster> ProductMasters { get; set; }
        public DbSet<ProductDetails> ProductDetailses { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductCatagory> ProductCatagories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
