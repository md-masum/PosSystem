using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Model
{
    public class ProductMaster
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string ItemName { get; set; }

        public ProductCatagory ProductCatagory { get; set; }
        public int ProductCatagoryId { get; set; }

        [Required]
        [StringLength(64)]
        public string Unit { get; set; }

        [Required]
        public int UnitValue { get; set; }

        public ProductDetails ProductDetails { get; set; }
        public int ProductDetailsId { get; set; }
    }

    public class ProductDetails
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double PurchasePrice { get; set; }

        [Required]
        public double SalePrice { get; set; }

        [Required]
        public DateTime StockEntryDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        public ProductPrice ProductPrice { get; set; }
        public int ProductPriceId { get; set; }
    }

    public class ProductPrice
    {
        public int Id { get; set; }
        [Required]
        public int ItemPrice { get; set; }

        public DateTime InsertDate { get; set; }

        
    }

    public class ProductCatagory
    {
        public int Id { get; set; }
        [Required]
        public string CatagoryName { get; set; }
    }
}
