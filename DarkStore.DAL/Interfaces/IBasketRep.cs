using DarkStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.DAL.Interfaces
{
    public interface IBasketRep:IBaseInterface<Basket>
    {
        Task<string> AddBasket(Basket basket);
    }
}
