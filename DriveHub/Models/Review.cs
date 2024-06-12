using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DriveHub.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        public int UserID { get; set; }
        public int CarID { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength]
        public string Comment { get; set; }

        public DateTime DatePosted { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }
    }
}
