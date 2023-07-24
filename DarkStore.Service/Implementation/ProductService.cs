using DarkStore.DAL.Interfaces;
using DarkStore.Domain.Entity;
using DarkStore.Domain.Response;
using DarkStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication6.Models;

using System.Security.Cryptography.X509Certificates;

namespace DarkStore.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRep _ProductRep;
        public ProductService(IProductRep productRep)
        {
            _ProductRep = productRep;
        }

        public async Task<BaseResponce<string>> AddProduct(Product newproduct)
        {
            BaseResponce<string> responce = new BaseResponce<string>();
            try
            {
                responce.Data = await _ProductRep.AddObject(newproduct);
                responce.StatusCode = Domain.ENUM.StatusCode.Ok;
                return responce;
            }
            catch (Exception ex)
            {
                responce.StatusCode = Domain.ENUM.StatusCode.IternaServerError;
                responce.Data = ex.Message;
                return responce;
            }
        }





            public async Task<BaseResponce<Product>> GetProductById(int id)
        {
            BaseResponce<Product> responce = new BaseResponce<Product>();
            try
            {
                List<Product> products = await _ProductRep.GetObjects();
                responce.Data = products.FirstOrDefault(x => x.Id  == id);
                if (responce.Data == null)
                {
                    responce.StatusCode = Domain.ENUM.StatusCode.ProductNotFounds;
                    responce.Description = "Продукт не был найден.";
                    return responce;
                }
                responce.Description = "";
                responce.StatusCode = Domain.ENUM.StatusCode.Ok;


                return responce;
            }
            catch (Exception ex)
            {
                responce.Description = ex.Message;
                responce.StatusCode = Domain.ENUM.StatusCode.IternaServerError;
                return responce;
            }
        }
        

        public async Task<BaseResponce<List<Product>>> GetProducts()
        {
            BaseResponce<List<Product>> responce = new BaseResponce<List<Product>>();
            try {
                responce.Data = await _ProductRep.GetObjects();
                if (responce.Data == null)
                {
                    responce.StatusCode = Domain.ENUM.StatusCode.ProductNotFounds;
                    responce.Description = "Продукты не были найденны.";
                    return responce;
                }
                responce.Description = "";
                responce.StatusCode = Domain.ENUM.StatusCode.Ok;            
 
               
                    return responce;
                
            }
            catch (Exception ex)
            {
                responce.Description = ex.Message;
                responce.StatusCode = Domain.ENUM.StatusCode.IternaServerError;
                return responce;
            }
            
        }

    }
}
