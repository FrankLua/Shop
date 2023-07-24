using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан Номер телефона")]
        [StringLength(16, ErrorMessage = "Номер телефона введён не верно")]
        public string PhoneNubmer { get; set; }
    }
}
