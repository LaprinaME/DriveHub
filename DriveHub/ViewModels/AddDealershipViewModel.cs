using System;
using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class AddDealershipViewModel
    {
        [Required(ErrorMessage = "Поле ID автосалона обязательно для заполнения")]
        public int DealershipID { get; set; }

        [Required(ErrorMessage = "Поле Название автосалона обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Название автосалона должно содержать не более 100 символов")]
        public string DealershipName { get; set; }

        [Required(ErrorMessage = "Поле Адрес обязательно для заполнения")]
        [StringLength(255, ErrorMessage = "Адрес должен содержать не более 255 символов")]
        public string Address { get; set; }

        [StringLength(20, ErrorMessage = "Телефон должен содержать не более 20 символов")]
        public string Phone { get; set; }
    }
}
