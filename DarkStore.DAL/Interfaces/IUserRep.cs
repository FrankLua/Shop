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

        Task <string> EditUser (User editorModel);

        Task<string> CheackNumber(string number);

        
    }
}
