using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveHub.Models
{
    public class CarBrand
    {
        [Key]
        public int BrandID { get; set; }

        [Required]
        [StringLength(50)]
        public string BrandName { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
    }
}
