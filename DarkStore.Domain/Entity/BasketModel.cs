using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.Domain.Entity
{
    public class BasketModel
    {
        
        public int ProductId { get; set; }
        public int UserId { get; set; }

        [MinLength(5, ErrorMessage = "Имя не должно быть меньше 5 символов")]
        [MaxLength(30, ErrorMessage = "Имя не должно превышать 50 символов")]
        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Имя")]

        public string FirstNameUser { get; set; }

        [MinLength(5, ErrorMessage = "Фамилия не должна быть меньше 5 символов")]
        [MaxLength(30, ErrorMessage = "Фамилия не должна превышать 50 символов")]
        [Required(ErrorMessage = "Не указана фамилия")]
        [Display(Name = "Фамилия")]

        public string SecondNameUser { get; set;}

        public string ProductName { get; set; }

        [MinLength(5, ErrorMessage = "Фамилия не должна быть меньше 5 символов")]
        [Display(Name = "Ваши пожелания")]
        public string DescriptionUser { get; set; }
        [StringLength(16, ErrorMessage = "Номер телефона введён не верно")]
        [Required(ErrorMessage = "Не указан номер телефона")]
        [Display(Name = "Номер телефона")]

        public string UserNumberPhone { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "Емайл")]

        public string UserEmail { get; set; }

        public DateTime UserDate { get; set; }


    }
    
}
