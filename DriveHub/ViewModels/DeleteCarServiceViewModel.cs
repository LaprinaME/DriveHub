using System;
using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class DeleteCarServiceViewModel
    {
        [Required(ErrorMessage = "Поле ID услуги обязательно для заполнения")]
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Поле Название услуги обязательно для заполнения")]
        [StringLength(100)]
        public string ServiceName { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Поле Цена обязательно для заполнения")]
        public decimal Price { get; set; }
    }
}
