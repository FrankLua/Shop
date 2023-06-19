using DarkStore.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.Service.Interfaces
{
    public interface IOrderService
    {
        public Task<BaseResponce<string>> AddOrder(User user);
    }
}
