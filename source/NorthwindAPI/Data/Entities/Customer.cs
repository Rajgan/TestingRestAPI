namespace NorthwindAPI.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customers")]
    public class Customer
    {
        [StringLength(5)]
        public String CustomerID { get; set; }
        [Required]
        [StringLength(40)]
        public String CompanyName { get; set; }
        [StringLength(30)]
        public String ContactName { get; set; }
        [StringLength(30)]
        public String ContactTitle { get; set; }
        [StringLength(60)]
        public String Address { get; set; }
        [StringLength(15)]
        public String City { get; set; }
        [StringLength(15)]
        public String Region { get; set; }
        [StringLength(10)]
        public String PostalCode { get; set; }
        [StringLength(15)]
        public String Country { get; set; }
        [StringLength(24)]
        public String Phone { get; set; }
        [StringLength(24)]
        public String Fax { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}