namespace NorthwindAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CategoryModel
    {
        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
    }
}