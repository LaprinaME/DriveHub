using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DriveHub.Models
{
    public class Dealership
    {
        [Key]
        public int DealershipID { get; set; }

        [Required]
        [StringLength(100)]
        public string DealershipName { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }
    }
}
