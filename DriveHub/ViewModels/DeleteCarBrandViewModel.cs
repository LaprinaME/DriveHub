using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class DeleteCarBrandViewModel
    {
        [Required(ErrorMessage = "Поле ID бренда обязательно для заполнения")]
        public int BrandID { get; set; }

        [Required(ErrorMessage = "Поле Название бренда обязательно для заполнения")]
        [StringLength(50)]
        public string BrandName { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
    }
}
