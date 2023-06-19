using DarkStore.DAL.Interfaces;
using DarkStore.Domain.Entity;
using DarkStore.Domain.ENUM;
using DarkStore.Domain.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.DAL.Repositories
{
    public class UserRep : IUserRep
    {
        private readonly ApplicationDbContext _Db;
        public UserRep(ApplicationDbContext db)
        {
            _Db = db;
        }

        public async Task<string> AddUser(RegisterModel newuser)
        {
            User user = new User { Email = newuser.Email, Password = newuser.Password, UserName = newuser.UserName };
            Role userRole = await _Db.Roles.FirstOrDefaultAsync(r => r.Name == "user");
            if (userRole != null)
                user.Role = userRole;
            string soursepatch = "C:\\Users\\sosis\\OneDrive\\Рабочий стол\\2323\\WebApplication6\\wwwroot\\AvatarsAcount\\Avatardefault\\Avatar.PNG";
            string patchfinish = $"C:\\Users\\sosis\\OneDrive\\Рабочий стол\\2323\\WebApplication6\\wwwroot\\AvatarsAcount\\{user.Email}";
            Directory.CreateDirectory(patchfinish);
            FileInfo DefImg = new FileInfo(soursepatch);
            string tempPath = Path.Combine(patchfinish, "Avatar.PNG");
            DefImg.CopyTo(tempPath, true);
            user.Img = $"/AvatarsAcount/{user.Email}/Avatar.PNG";

            _Db.Users.Add(user);
            await _Db.SaveChangesAsync();
            return "Регистрация прошла успешно";
        }

        public async Task<BaseReponcefeedback> EditUser(EditorModel user)
        {
            try
            {
                User OldUser = await _Db.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
                OldUser.UserName = user.UserName;
                OldUser.Password = user.Password;

                var fileName = "Avatar.PNG";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"C:\\Users\\sosis\\OneDrive\\Рабочий стол\\2323\\WebApplication6\\wwwroot\\AvatarsAcount\\{user.Email}", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await user.Imgform.CopyToAsync(fileStream);
                }
                _Db.SaveChanges();
                string Descreption = "Данные изменены";
                BaseReponcefeedback baseResponce = new BaseReponcefeedback();
                baseResponce.Description = Descreption;
                baseResponce.StatusCode = StatusCode.Ok;
                return baseResponce;
            }
            catch
            {
                string Descreption = "Произошла ошибка, данные не записаны (UserRep)";
                BaseReponcefeedback baseResponce = new BaseReponcefeedback();
                baseResponce.Description = Descreption;
                baseResponce.StatusCode = StatusCode.IternaServerError;
                return baseResponce;
            }
        }

        public IEnumerable<User> GetObjects()
        {
            return _Db.Users.ToList();
        }

        public async Task<User> GetUserFindEmail(string email)
        {
            User user = await _Db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                int roleid = user.RoleId;
                Role role = await _Db.Roles.FirstOrDefaultAsync(u => u.Id == roleid);
                user.Role = role;
                IEnumerable<FeedBack> feedBacks = _Db.feedback.Where(u => u.UserId == user.Id);
                user.Comments = feedBacks.ToList();
                IEnumerable<Basket> basketall = _Db.Basket.Where(o => o.UserId == user.Id);
                IEnumerable<Basket> basketsaction = _Db.Basket.Where(o => o.UserId == user.Id && o.Paid == false);
                IEnumerable<Basket> basketspaid = _Db.Basket.Where(o => o.UserId == user.Id && o.Paid == true);
                foreach (Basket basket in basketsaction)
                {
                    basket.Product = await _Db.Products.FirstOrDefaultAsync(x => x.Id == basket.IdProduct);
                }
                foreach (Basket basket in basketall)
                {
                    basket.Product = await _Db.Products.FirstOrDefaultAsync(x => x.Id == basket.IdProduct);
                }
                foreach (Basket basket in basketspaid)
                {
                    basket.Product = await _Db.Products.FirstOrDefaultAsync(x => x.Id == basket.IdProduct);
                }
                user.Basket = basketall.ToList();
                user.BasketAction = basketsaction.ToList();
                user.BasketPaid = basketspaid.ToList();
                return await Task.FromResult(user);
            }
            
            return await Task.FromResult(user);
        }

        public User GetUserFindId(int id)
        {
            User user = _Db.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        Task<User> IUserRep.GetUserFindId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
