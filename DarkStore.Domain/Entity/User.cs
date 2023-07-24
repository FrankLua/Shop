using DarkStore.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models;

namespace WebApplication6.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string UserName { get ; set; }

        public string SecondName { get; set; }  
        public string Email { get; set; }
        public string Password { get; set; }

        public string NumberPhone { get; set; } 
        public int RoleId { get; set; }
        
        public string SrcImg { get; set; }
     



        public Role Role { get; set; }
        
        
        [NotMapped]
        public List<Basket> Basket { get; set; }
        [NotMapped]

        public List<FeedBack> Comments { get; set; }
        [NotMapped]
        public List<Achievment> Achievements { get; set; }
        public User() 
        { 
            Achievements = new List<Achievment>();
            Comments = new List<FeedBack>();
            Basket = new List<Basket>();            

        }
        public static User BuildUser(RegisterModel model)
        {
            Role role = new Role { Id = 2, Name = "User" };
            User user = new User
            {
                NumberPhone = model.PhoneNumber,
                SecondName = model.SecondName,
                Email = model.Email,
                Password = model.Password,
                UserName = model.UserName,                
                RoleId = 2
            };
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var soursepatch = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + "\\Images\\DefAvatarUser\\Avatar.JPG";
            string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            
            string patchfinish = $"{wwwRootPath}\\UserAcounts\\{user.Email}";
            Directory.CreateDirectory(patchfinish);
            FileInfo DefImg = new FileInfo(soursepatch);
            string tempPath = Path.Combine(patchfinish, "Avatar.PNG");
            DefImg.CopyTo(tempPath, true);
            user.SrcImg = $"/UserAcounts/{user.Email}/Avatar.PNG";
            return user;
        }
        public static void EditdUser(EditorModel newUser , User oldUser )
        {
            oldUser.UserName = newUser.UserName;
            oldUser.SecondName = newUser.SecondName;
            oldUser.NumberPhone = newUser.PhoneNumber;
            
            oldUser.Password = newUser.Password;
            string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            string patchfinish = $"{wwwRootPath}\\UserAcounts\\{newUser.Email}";
            var fileName = "Avatar.PNG";
            string tempPath = Path.Combine(patchfinish, fileName);

            using (var fileStream = new FileStream(tempPath, FileMode.Create))
            {
               newUser.Imgform.CopyTo(fileStream);
            }
            
        }

    }



}

