using DarkStore.DAL.Interfaces;
using DarkStore.DAL.Repositories;
using DarkStore.Domain.Entity;
using DarkStore.Domain.ENUM;
using DarkStore.Domain.Response;
using DarkStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.Service.Implementation
{
    public  class UserService : IUserService
    {
        private readonly IUserRep _UserRep;
        private readonly IAchievementRep _AchievementRep;
        public UserService (IUserRep userRep , IAchievementRep achievementRep)
        {
            _AchievementRep = achievementRep;
            _UserRep = userRep;
        }

        public async Task<BaseResponce<string>> AddUser(RegisterModel newuser)
        {
            var baseResponce = new BaseResponce<string>();
            try
            {
                var list = Achievment.AchievemetBuild(newuser);
                foreach (var item in list)
                {
                     await _AchievementRep.AddObject(item);
                }
                User user = new User();
                user = User.BuildUser(newuser);
                baseResponce.Data = await _UserRep.AddObject(user);
                baseResponce.StatusCode = Domain.ENUM.StatusCode.Ok;
                baseResponce.Description = "";
                return baseResponce;
            }
            catch (Exception ex)
            {
                baseResponce.Data = ex.Message;
                baseResponce.StatusCode = Domain.ENUM.StatusCode.IternaServerError;
                baseResponce.Description = "";
                return baseResponce;
            }
        }

      

        public async Task<string> EditUser(EditorModel editorModel , User oldUser)
        {
            BaseResponce<string> baseResponce = new BaseResponce<string>();
            try
            {

 
                User.EditdUser(editorModel, oldUser);
                await _UserRep.EditUser(oldUser);
                string Descreption = "Данные изменены";                
                baseResponce.Description = Descreption;
                baseResponce.StatusCode = StatusCode.Ok;
                return baseResponce.Data;
            }
            catch (Exception ex)
            {
                string Descreption = "Произошла ошибка, данные не записаны (UserRep)";                
                baseResponce.Description = Descreption;
                baseResponce.StatusCode = StatusCode.IternaServerError;
                return baseResponce.Data;
            }
            
        }

        public async Task<BaseResponce<User>> GetUserFindEmail(string email)
        {
            var baseResponce = new BaseResponce<User>();
            try
            {
                List<User> users = await _UserRep.GetObjects();
                User user = users.FirstOrDefault(x => x.Email == email);
                baseResponce.Data = user;
                baseResponce.StatusCode = Domain.ENUM.StatusCode.Ok;
                return  baseResponce;
            }
            catch (Exception ex) 
            {
                return new BaseResponce<User>()
                {
                    Description = $"GetUserId = {ex.Message}",
                };
            }
        }

        public async Task<BaseResponce<string>> CheakNumber(string number)
        {
            var baseResponce = new BaseResponce<string>();
            try
            {
                baseResponce.Data = await _UserRep.CheackNumber(number);
                if(baseResponce.Data != null)
                {
                    baseResponce.StatusCode = Domain.ENUM.StatusCode.Ok;
                    baseResponce.Description = "";
                    return baseResponce;
                }
                else
                {
                    baseResponce.StatusCode = Domain.ENUM.StatusCode.UsernotFound;
                    baseResponce.Description = "";
                    return baseResponce;

                }
            }
            catch (Exception ex)
            {
                baseResponce.Data = ex.Message;
                baseResponce.StatusCode = Domain.ENUM.StatusCode.IternaServerError;
                baseResponce.Description = "";
                
                return baseResponce;
            }
        }
    }
}
