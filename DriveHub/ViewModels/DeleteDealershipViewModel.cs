using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class DeleteDealershipViewModel
    {
        [Required(ErrorMessage = "Поле ID автосалона обязательно для заполнения")]
        public int DealershipID { get; set; }

        [Required(ErrorMessage = "Поле Название автосалона обязательно для заполнения")]
        [StringLength(100)]
        public string DealershipName { get; set; }

        [Required(ErrorMessage = "Поле Адрес обязательно для заполнения")]
        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }
    }
}
