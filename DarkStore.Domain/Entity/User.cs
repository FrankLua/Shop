using DarkStore.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models;

namespace WebApplication6.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string UserName { get ; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        
        public string Img { get; set; }
     



        public Role Role { get; set; }
        public List<Basket> Basket { get; set; }
        [NotMapped]
        public List<Basket> BasketAction { get; set; }
        [NotMapped]
        public List<Basket> BasketPaid { get; set; }
        public List<FeedBack> Comments { get; set; }
        public User() 
        { 
            Comments = new List<FeedBack>();
            Basket = new List<Basket>();
            BasketAction = new List<Basket>();
            BasketPaid = new List<Basket>();
        }

        
    }


}

