using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DriveHub.Models
{
    public class FavoriteCar
    {
        [Key]
        public int FavoriteID { get; set; }

        public int UserID { get; set; }
        public int CarID { get; set; }

        public DateTime DateAdded { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }
    }
}
