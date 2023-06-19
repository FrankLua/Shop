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
        [Required(ErrorMessage = "Не указано имя")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
        public IFormFile Imgform { get; set; }
        public string Email { get; set; }   


    }
}
