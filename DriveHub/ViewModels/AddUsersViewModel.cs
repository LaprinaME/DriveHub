using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class AddUsersViewModel
    {
        public int UserID { get; set; } // Поле для ввода ID

        [Required(ErrorMessage = "Поле Имя пользователя обязательно для заполнения")]
        [StringLength(50, ErrorMessage = "Имя пользователя должно содержать не более 50 символов")]
        [Display(Name = "Имя пользователя")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Поле Пароль обязательно для заполнения")]
        [StringLength(255, ErrorMessage = "Пароль должен содержать не более 255 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Роль")]
        public int RoleID { get; set; }
    }
}
