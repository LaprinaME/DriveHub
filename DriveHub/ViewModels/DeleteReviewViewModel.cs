using System;
using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class DeleteReviewViewModel
    {
        [Required(ErrorMessage = "Поле ID отзыва обязательно для заполнения")]
        public int ReviewID { get; set; }

        public int UserID { get; set; }
        public int CarID { get; set; }

        [Range(1, 5, ErrorMessage = "Рейтинг должен быть от 1 до 5")]
        public int Rating { get; set; }

        public string Comment { get; set; }

        [Required(ErrorMessage = "Поле Дата добавления обязательно для заполнения")]
        public DateTime DatePosted { get; set; }

        public string UserName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
    }
}
