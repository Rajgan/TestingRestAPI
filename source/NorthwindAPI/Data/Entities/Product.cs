namespace NorthwindAPI.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Products")]
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(40)]
        public String ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        [StringLength(20)]
        public String QuantityPerUnit { get; set; }
        [Column(TypeName = "money")]
        public decimal?UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}