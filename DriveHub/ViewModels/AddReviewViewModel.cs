using System;
using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class AddReviewViewModel
    {
        [Required(ErrorMessage = "Поле ID отзыва обязательно для заполнения")]
        public int ReviewID { get; set; }

        [Required(ErrorMessage = "Поле ID пользователя обязательно для заполнения")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Поле ID автомобиля обязательно для заполнения")]
        public int CarID { get; set; }

        [Range(1, 5, ErrorMessage = "Рейтинг должен быть от 1 до 5")]
        public int Rating { get; set; }

        public string Comment { get; set; }

        [Required(ErrorMessage = "Поле Дата добавления обязательно для заполнения")]
        public DateTime DatePosted { get; set; }
    }
}
