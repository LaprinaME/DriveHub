using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveHub.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Имя пользователя")]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Роль")]
        public int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Roles { get; set; }
    }
}