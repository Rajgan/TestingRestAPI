namespace NorthwindAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProductModel
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(40)]
        public String ProductName { get; set; }
        public CategoryModel Category { get; set; }
        [StringLength(20)]
        public String QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual SupplierModel Supplier { get; set; }
    }
}