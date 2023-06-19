
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class RegisterModel
    {
        [MinLength(5, ErrorMessage = "Имя не должно быть меньше 5 символов")]
        [MaxLength(30, ErrorMessage ="Имя не должно превышать 50 символов")]
        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name ="Имя")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Не указан Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name ="Емайл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }
    }

}
