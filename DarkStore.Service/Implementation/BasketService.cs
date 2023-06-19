using DarkStore.DAL.Interfaces;
using DarkStore.Domain.Entity;
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
    public class BasketService : IBasketService
    {
        private readonly IBasketRep _BasketRepRep;
        public BasketService(IBasketRep basketRep)
        {
            _BasketRepRep = basketRep;
        }
        public Basket Data => throw new NotImplementedException();

        public async Task<BaseResponce<string>> AddBasket(Basket basket)
        {
            var baseResponce = new BaseResponce<string>();
            try
            {
                baseResponce.Data = await _BasketRepRep.AddBasket(basket);
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



        public async Task<BaseResponce<Basket>> BuildBasket(BasketModel basketmodel, Product productbasket)
        {
            var baseResponce = new BaseResponce<Basket>();
            Basket basket = new Basket();

            try
            {
                basket.IdProduct = basketmodel.IdProduct;
                basket.UserId = basketmodel.UserId;
                basket.Quantity = basketmodel.Quantity;
                basket.Product = productbasket;
                baseResponce.Data = basket;
                             
                baseResponce.StatusCode =Domain.ENUM.StatusCode.Ok;
                baseResponce.Description = "";
                return baseResponce;
            }
            catch(Exception ex)
            {
                baseResponce.StatusCode = Domain.ENUM.StatusCode.IternaServerError;
                baseResponce.Description = ex.Message;
                return baseResponce;
            }
        }
    }
}
