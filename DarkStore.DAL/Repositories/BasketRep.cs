using DarkStore.DAL.Interfaces;
using DarkStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.DAL.Repositories
{
    public class BasketRep : IBasketRep
    {
        private readonly ApplicationDbContext _Db;
        public BasketRep(ApplicationDbContext db)
        {
            _Db = db;
        }
        public async Task<string> AddBasket(Basket basket)
        {
            _Db.Add(basket);
            _Db.SaveChanges();
            string answer = "Добавленно в корзину!";
            return answer;
            
        }

        public IEnumerable<Basket> GetObjects()
        {
            throw new NotImplementedException();
        }
    }
}
