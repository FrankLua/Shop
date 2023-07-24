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



        public async Task<string> AddObject(User user)
        {    

            _Db.Users.Add(user);
            await _Db.SaveChangesAsync();
            return "Регистрация прошла успешно";
        }

        public async Task<string> CheackNumber(string number)
        {
            if( await _Db.Users.FirstAsync( c => c.NumberPhone  == number) != null)
            {
                return  "Номер пользователя найден";
            }
            else
            {
                return null;
            }
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
                
                

                

                user.Basket = basketall.ToList();
      
                return await Task.FromResult(user);
            }
            
            return await Task.FromResult(user);
        }



        public async Task<string> EditUser(User newUser)
        {
            _Db.Users.Update(newUser);
             _Db.SaveChanges();
            return "Ok";
        }

        async Task<List<User>> IBaseInterface<User>.GetObjects()
        {
            List<User> Users = await _Db.Users.ToListAsync();
            foreach (User user in Users)
            {
                int roleid = user.RoleId;
                Role role = await _Db.Roles.FirstOrDefaultAsync(u => u.Id == roleid);
                user.Role = role;
                IEnumerable<FeedBack> feedBacks = _Db.feedback.Where(u => u.UserId == user.Id);
                user.Comments = feedBacks.ToList();
                IQueryable<Basket> basketall = from Basket in _Db.Basket
                                          select new Basket()
                                          {
                                              Id = Basket.Id,
                                              FirstNameUser = Basket.FirstNameUser,
                                              State = Convert.ToBoolean(Basket.State),
                                              ProductId = Basket.ProductId,
                                              UserId = Basket.UserId,
                                              SecondNameUser = Basket.SecondNameUser,
                                              ProductName = Basket.ProductName,
                                              DescriptionUser = Basket.DescriptionUser,
                                              UserNumberPhone = Basket.UserNumberPhone,
                                              UserEmail = Basket.UserEmail,
                                              UserDate = Basket.UserDate,
                                          };
                basketall = basketall.Where(x => x.UserEmail == user.Email);

                List<Achievment> achievmentslist = _Db.Achievment.Where(x => x.UserEmail == user.Email).ToList();
                
                user.Achievements = achievmentslist.ToList();               
                user.Basket = basketall.ToList();


            }
            return Users;
        }


    }
}
