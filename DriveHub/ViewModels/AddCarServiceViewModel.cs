using System;
using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class AddCarServiceViewModel
    {
        [Required(ErrorMessage = "Поле ID услуги обязательно для заполнения")]
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Поле Название услуги обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Название услуги должно содержать не более 100 символов")]
        public string ServiceName { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Поле Цена обязательно для заполнения")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше 0")]
        public decimal Price { get; set; }
    }
}
