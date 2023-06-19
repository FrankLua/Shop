using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkStore.Domain.Entity;
using DarkStore.Domain.Response;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication6.Models;

namespace DarkStore.Service.Interfaces
{
    public interface IUserService
    {
        public Task<BaseResponce<User>> GetUserFindEmail(string email);
        public Task<BaseReponcefeedback> EditUser(EditorModel editorModel);

        public Task<BaseResponce<string>> AddUser(RegisterModel newuser);
        
    }
}
