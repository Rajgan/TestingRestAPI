namespace NorthwindAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ShipperModel
    {
        public int ShipperID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }
    }
}