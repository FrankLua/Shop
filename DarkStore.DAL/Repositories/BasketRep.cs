using DarkStore.DAL.Interfaces;
using DarkStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public async Task <string> AddObject(Basket basket)
        {
            _Db.Basket.Add(basket);
            await _Db.SaveChangesAsync();            
            return "Добавленно в корзину!";
            
        }

        public async Task<string> DeleteBasket(List<Basket> listbasket)
        {
            foreach(var item in listbasket)
            {
                _Db.Basket.Remove(item);
                
            }
             _Db.SaveChanges();

            return "Данные удалены.";
        }

        public async Task<List<Basket>> GetObjects()
        {
            
            IQueryable<Basket> list = from Basket in  _Db.Basket
                        select new Basket() { Id = Basket.Id, 
                            FirstNameUser = Basket.FirstNameUser, 
                            State = Convert.ToBoolean(Basket.State),
                            ProductId = Basket.ProductId,
                            UserId = Basket.UserId,
                            SecondNameUser = Basket.SecondNameUser,
                            ProductName = Basket.ProductName,
                            DescriptionUser = Basket.DescriptionUser,
                            UserNumberPhone = Basket.UserNumberPhone,
                            UserEmail = Basket.UserEmail, 
                            UserDate = Basket.UserDate,
                        };
            
            return list.ToList();

        }

        public async Task UpdateBasket(Basket basket)
        {
            _Db.Update(basket);
            await _Db.SaveChangesAsync();
        }
    }
}
