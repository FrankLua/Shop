using DarkStore.DAL.Interfaces;
using DarkStore.Domain.Entity;
using DarkStore.Domain.Response;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication6.Models;


namespace DarkStore.DAL.Repositories
{
    public class ProductRep : IProductRep
    {
        private readonly ApplicationDbContext _Db;
        public ProductRep(ApplicationDbContext db)
        {
            _Db = db;
        }

        public async Task<string> AddObject(Product newproduct)
        {

            _Db.Add(newproduct);
            await _Db.SaveChangesAsync();
            return "Продукт внесён в базу данных, проверьте на главной странице";

        }




        async Task<List<Product>> IBaseInterface<Product>.GetObjects()
        {
            try
            {

                List<Product> products = _Db.Products.ToList();
                foreach (Product product in products)
                {
                    List<FeedBack> feedBacks = await _Db.feedback.Where(o => o.ProductId == product.Id).ToListAsync();
                    product.Productcomment = feedBacks;
                    List<PicСarrier> pics = await _Db.ProductSrc.Where(o => o.ProductId == product.Id).ToListAsync();                    
                    product.ProductPic = pics;
                    

                }

                return  products;
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public async Task<string> SaveProduct(Product Oldproduc)
        {
            
           _Db.Update(Oldproduc);
           await _Db.SaveChangesAsync();
           return "Изменения внесены";
        }

        
       
    }
}
