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

        public async Task<BaseResponce<string>> AddBasket(BasketModel basket)
        {
            var baseResponce = new BaseResponce<string>();
            try
            {               
                baseResponce.Data = await _BasketRepRep.AddObject(Basket.BuildBasket(basket));
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

        public async Task<BaseResponce<List<Basket>>> GetBasket()
        {
            BaseResponce<List<Basket>> baseResponce = new BaseResponce<List<Basket>>();
            try
            {
                baseResponce.Data = await _BasketRepRep.GetObjects();
                baseResponce.StatusCode = Domain.ENUM.StatusCode.Ok;
                baseResponce.Description = "";
                return baseResponce;


            }
            catch (Exception ex)
            {
                baseResponce.Data = null;
                baseResponce.StatusCode = Domain.ENUM.StatusCode.IternaServerError;
                baseResponce.Description = ex.Message;
                return baseResponce;

            }

        }

        public async Task<BaseResponce<List<Basket>>> GetBasketbyId(int id)
        {
            BaseResponce<List<Basket>> baseResponce = new BaseResponce<List<Basket>>();
            try
            {
                var list = await _BasketRepRep.GetObjects();                
                baseResponce.Data = list.Where(x => x.UserId == id).ToList();
                baseResponce.StatusCode = Domain.ENUM.StatusCode.Ok;
                baseResponce.Description = "";
                return baseResponce;


            }
            catch (Exception ex)
            {
                baseResponce.Data = null;
                baseResponce.StatusCode = Domain.ENUM.StatusCode.IternaServerError;
                baseResponce.Description = ex.Message;
                return baseResponce;

            }
        }

        public async Task<BaseResponce<string>> UpdateBasket(Basket basket)
        {
            BaseResponce<string> baseResponce = new BaseResponce<string>();
            try
            {
                basket.State = true;
                await _BasketRepRep.UpdateBasket(basket);
                baseResponce.Data = "ok";
                baseResponce.StatusCode = Domain.ENUM.StatusCode.Ok;
                baseResponce.Description = "";
                return baseResponce;


            }
            catch (Exception ex)
            {
                baseResponce.Data = null;
                baseResponce.StatusCode = Domain.ENUM.StatusCode.IternaServerError;
                baseResponce.Description = ex.Message;
                return baseResponce;

            }

        }
    }
}
