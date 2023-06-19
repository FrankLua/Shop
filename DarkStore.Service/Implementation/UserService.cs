using DarkStore.DAL.Interfaces;
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
        public UserService (IUserRep userRep)
        {
            _UserRep = userRep;
        }

        public async Task<BaseResponce<string>> AddUser(RegisterModel newuser)
        {
            var baseResponce = new BaseResponce<string>();
            try
            {
                baseResponce.Data = await _UserRep.AddUser(newuser);
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

        public async Task<BaseReponcefeedback> EditUser(EditorModel editorModel)
        {
            BaseReponcefeedback baseresponce = await _UserRep.EditUser(editorModel);
           return baseresponce;
        }

        public async Task<BaseResponce<User>> GetUserFindEmail(string email)
        {
            var baseResponce = new BaseResponce<User>();
            try
            {
                User user = await _UserRep.GetUserFindEmail(email);
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


    }
}
