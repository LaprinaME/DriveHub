using System;
using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class DeleteFavoriteCarViewModel
    {
        [Required(ErrorMessage = "Поле ID избранного автомобиля обязательно для заполнения")]
        public int FavoriteID { get; set; }

        public int UserID { get; set; }
        public int CarID { get; set; }

        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
