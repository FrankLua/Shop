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
    public class OrderService : IOrderService
    {
        private readonly IOrderRep _OrderRep;
        public OrderService(IOrderRep orderRep)
        {
            _OrderRep = orderRep;
        }
        public async Task<BaseResponce<string>> AddOrder(User user)
        {
            var baseResponce = new BaseResponce<string>();
            try 
            {
                baseResponce.Data = await _OrderRep.AddOrder(user);
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
    }
}
