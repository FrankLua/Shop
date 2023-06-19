using DarkStore.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.DAL.Interfaces
{
    public interface IUserRep : IBaseInterface<User>
    {
        Task <User> GetUserFindId(int id);
        Task <User> GetUserFindEmail(string email);
        Task <BaseReponcefeedback> EditUser (EditorModel editorModel);

        Task<string> AddUser(RegisterModel newuser);
    }
}
