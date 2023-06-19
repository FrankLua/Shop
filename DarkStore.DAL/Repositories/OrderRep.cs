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
    public class OrderRep : IOrderRep 
    {
        private readonly ApplicationDbContext _Db;
        public OrderRep(ApplicationDbContext db)
        {
            _Db = db;
        }
        public async Task<string> AddOrder(User user)
        {
           
            
            Order order = new Order();
            Product product = new Product();
            var baskets = user.BasketAction.ToList();
            order.UserId = user.Id;

            try 
            {                
                foreach (var basket in baskets)
                {
                    if (basket.Paid == false)
                    {                       
                        order.FullPrice += basket.Product.Price * basket.Quantity;
                        product = basket.Product;
                        product.Count -= basket.Quantity;
                        basket.Paid = true;
                        _Db.SaveChanges();
                    }
                }              
                _Db.Orders.Add(order);
                _Db.SaveChanges();
                string answer = $"Ваш заказ сформирован был сформирован на имя {user.UserName}, ожидайте получения ";
                return  answer;
            }
            catch (Exception ex) 
            {
                string answer = $"Произошла ошибка при добавлении заказа. Kod{ex.Message}";
                return answer;
            }
        }

        public IEnumerable<Order> GetObjects()
        {
            throw new NotImplementedException();
        }

        IEnumerable<string> IBaseInterface<string>.GetObjects()
        {
            throw new NotImplementedException();
        }
    }
}
