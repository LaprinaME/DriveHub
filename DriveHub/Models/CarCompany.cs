using System.ComponentModel.DataAnnotations;

namespace DriveHub.Models
{
    public class CarCompany
    {
        [Key]
        public int CompanyID { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
