namespace NorthwindAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrderDetailModel
    {
        public virtual ProductModel Product { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}