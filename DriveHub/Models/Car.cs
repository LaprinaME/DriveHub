using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DriveHub.Models
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int Mileage { get; set; }

        [MaxLength]
        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<FavoriteCar> FavoriteCars { get; set; }
    }

}
