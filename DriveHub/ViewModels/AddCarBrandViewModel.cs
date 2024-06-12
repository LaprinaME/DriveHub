using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class AddCarBrandViewModel
    {
        public int BrandID { get; set; } // Добавлено поле для ввода ID

        [Required(ErrorMessage = "Поле Название бренда обязательно для заполнения")]
        [StringLength(50, ErrorMessage = "Название бренда должно содержать не более 50 символов")]
        public string BrandName { get; set; }

        [StringLength(50, ErrorMessage = "Название страны должно содержать не более 50 символов")]
        public string Country { get; set; }
    }
}
