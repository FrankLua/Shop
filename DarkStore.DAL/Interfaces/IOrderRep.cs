using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.DAL.Interfaces
{
    public interface IOrderRep : IBaseInterface<string>
    {
        Task<string> AddOrder(User user);
    }
}
