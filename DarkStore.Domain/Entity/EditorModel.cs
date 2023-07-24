using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class EditorModel
    {
        [MinLength(5, ErrorMessage = "Имя не должно быть меньше 5 символов")]
        [MaxLength(30, ErrorMessage = "Имя не должно превышать 50 символов")]
        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Имя")]
        public string UserName { get; set; }

        [MinLength(5, ErrorMessage = "Фамилия не должна быть меньше 5 символов")]
        [MaxLength(30, ErrorMessage = "Фамилия не должна превышать 50 символов")]
        [Required(ErrorMessage = "Не указана фамилия")]
        [Display(Name = "Фамилия")]
        
        public string SecondName { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Не указан повторый пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Повторный пароль введен неверно")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }

        [StringLength(16, ErrorMessage = "Номер телефона введён не верно")]
        [Required(ErrorMessage = "Не указан номер телефона")]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        public IFormFile Imgform { get; set; }

        public string Email { get; set; }   
          


    }
}
