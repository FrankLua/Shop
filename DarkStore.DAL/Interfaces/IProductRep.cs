using DarkStore.Domain.Entity;
using DarkStore.Domain.Response;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

using WebApplication6.Models;
using DarkStore.Domain.ModelViews;

namespace DarkStore.DAL.Interfaces
{
    public interface IProductRep:IBaseInterface<List<Product>>
    {
        Task<Product> BuildProduct(ProductModel newProduct);
       Task <List<Product>> GetProducts();
       Task<Product> GetProductById(int id);
       Task<string> AddProduct(Product newproduct);
        Task<string> SaveProduct(Product Oldproduct);
        Task <List<SelectListItem>> GetCountryList();


    }
}
