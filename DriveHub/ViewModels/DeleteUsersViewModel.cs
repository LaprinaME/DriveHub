using System.ComponentModel.DataAnnotations;

namespace DriveHub.ViewModels
{
    public class DeleteUsersViewModel
    {
        [Required(ErrorMessage = "Поле ID пользователя обязательно для заполнения")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Поле Имя пользователя обязательно для заполнения")]
        [StringLength(50)]
        public string Username { get; set; }
    }
}
