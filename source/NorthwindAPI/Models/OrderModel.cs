
namespace NorthwindAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OrderModel
    {
        public int OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public ShipperModel ShipVia { get; set; }
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
        public IEnumerable<OrderDetailModel> OrderDetails { get; set; }
    }
}