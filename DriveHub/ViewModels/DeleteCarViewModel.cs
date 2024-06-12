using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class DeleteCarViewModel
    {
        [Display(Name = "ID автомобиля")]
        public int CarID { get; set; }

        [Display(Name = "Марка")]
        public string Make { get; set; }

        [Display(Name = "Модель")]
        public string Model { get; set; }

        [Display(Name = "Год")]
        public int Year { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Пробег")]
        public int Mileage { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Дата добавления")]
        public DateTime DateAdded { get; set; }
    }
}
