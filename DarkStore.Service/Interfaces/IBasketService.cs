using DarkStore.Domain.Entity;
using DarkStore.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.Service.Interfaces
{
    public interface IBasketService:IBaseResponse<Basket>
    {
        Task<BaseResponce<string>> AddBasket(Basket basket);
        Task<BaseResponce<Basket>> BuildBasket(BasketModel basketmodel,Product productbasket);
    }
}
