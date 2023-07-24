using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.Domain.Entity
{
    public class FeedbackModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        [Required(ErrorMessage = "Не указана оценка")]
        public int Review { get; set; }
        [Required(ErrorMessage = "Не указан отзыв")]
        [MinLength(5, ErrorMessage = "Отзыв должен быть не менее 10 символов")]
        
        public string Comments { get; set; }
        
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string Usersrc { get; set; }
        public static void FeedbackBuild(FeedbackModel model, FeedBack feedBack)
        {
            feedBack.UserId = model.UserId;
            feedBack.Usersrc = model.Usersrc;
            feedBack.Review = model.Review;
            feedBack.Comments = model.Comments;
            feedBack.FirstName = model.FirstName;
            feedBack.SecondName = model.SecondName;
            feedBack.Data = DateTime.Now;
            feedBack.ProductId = model.ProductId;
            feedBack.ProductName = model.ProductName;
        }
    }
    
}
