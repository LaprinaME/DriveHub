using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class AddCarsViewModel
    {
        [Required(ErrorMessage = "Поле Код автомобиля (ID) обязательно для заполнения")]
        public int CarID { get; set; }

        [Required(ErrorMessage = "Поле Марка обязательно для заполнения")]
        [StringLength(50, ErrorMessage = "Марка автомобиля должна содержать не более 50 символов")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Поле Модель обязательно для заполнения")]
        [StringLength(50, ErrorMessage = "Модель автомобиля должна содержать не более 50 символов")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Поле Год обязательно для заполнения")]
        [Range(1900, 2100, ErrorMessage = "Введите корректный год выпуска автомобиля")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Поле Цена обязательно для заполнения")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Поле Пробег обязательно для заполнения")]
        [Range(0, int.MaxValue, ErrorMessage = "Пробег должен быть больше или равен 0")]
        public int Mileage { get; set; }

        public string Description { get; set; }
    }
}
