namespace NorthwindAPI.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }        
        public String CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        [Column(TypeName = "money")]
        public decimal? Freight { get; set; }
        [StringLength(40)]
        public String ShipName { get; set; }
        [StringLength(60)]
        public String ShipAddress { get; set; }
        [StringLength(15)]
        public String ShipCity { get; set; }
        [StringLength(15)]
        public String ShipRegion { get; set; }
        [StringLength(10)]
        public String ShipPostalCode { get; set; }
        [StringLength(15)]
        public String ShipCountry { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails{ get; set; }

    }
}