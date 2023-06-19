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
using DarkStore.Domain.ModelViews;

namespace DarkStore.DAL.Repositories
{
    public class ProductRep : IProductRep
    {
        private readonly ApplicationDbContext _Db;
        public ProductRep(ApplicationDbContext db)
        {
            _Db = db;
        }

        public async Task<string> AddProduct(Product newproduct)
        {

            _Db.Add(newproduct);
            _Db.SaveChanges();
            return "Продукт внесён в базу данных, проверьте на главной странице";

        }

        public async Task<Product> BuildProduct(ProductModel newProduct)
        {
            Product product = new Product();
            product.FullDescription = newProduct.FullDescription;
            product.LiteDescription = newProduct.LiteDescription;
            product.Price = newProduct.Price;
            product.Count = newProduct.Count;
            product.Title = newProduct.Title;
            product.CountryId = newProduct.CountryId;  
            product.Country = await _Db.Country.FirstOrDefaultAsync(x => x.Code == newProduct.CountryId);
            var patch = $"C:\\Users\\sosis\\OneDrive\\Рабочий стол\\2323\\WebApplication6\\wwwroot\\Images\\ProductIMG\\{product.Title}";
            Directory.CreateDirectory(patch);
            var fileName = "ProductIMG.PNG";
            var filePath = Path.Combine(patch, fileName);
            
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await newProduct.Imgform.CopyToAsync(fileStream);
            }
            if (newProduct.Id > 0) { product.Id = newProduct.Id; }
            var subpreviw = $"/Images/ProductIMG/{product.Title}/{fileName}";
            product.SubPreview = subpreviw;
            return product;
        }

        public async Task<List<SelectListItem>> GetCountryList()
        {
            List<Country> list = new List<Country>();
            list =  _Db.Country.ToList();
            List<SelectListItem> selectlist = 
                _Db.Country.OrderBy(n => n.Name)
                .Select(n => new SelectListItem
                {Value = n.Code,Text = n.Name }).ToList();

            
            return selectlist;
        }

        public IEnumerable<List<Product>> GetObjects()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductById(int id)
        {
           Product product = await _Db.Products.FirstOrDefaultAsync(x => x.Id == id);
           List<FeedBack> feedBacks = _Db.feedback.Where(o => o.ProductId == product.Id).ToList();
            product.Country = await _Db.Country.FirstOrDefaultAsync(x => x.Code == product.CountryId);
           product.Productcomment = feedBacks;
           return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            
            try
            {
                
                List<Product> products = _Db.Products.ToList();
                foreach (Product product in products)
                {
                    List<FeedBack> feedBacks =_Db.feedback.Where(o => o.ProductId == product.Id).ToList();
                    product.Productcomment = feedBacks;

                }

                return products;
            }
            catch (Exception ex) 
            {

                return null;
            }

        }

        public async Task<string> SaveProduct(Product Oldproduc)
        {
            
            _Db.Update(Oldproduc);
           await  _Db.SaveChangesAsync();
            return "Изменения внесены";
        }
    }
}
