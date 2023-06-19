using DarkStore.Domain.Entity;
using DarkStore.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication6.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DarkStore.Domain.ModelViews;

namespace DarkStore.Service.Interfaces
{
    public interface IProductService

    {
        public Task<BaseResponce<Product>> BuildProduct(ProductModel newProduct);
        public Task<BaseResponce<List<Product>>> GetProducts();
        public Task<BaseResponce<Product>> GetProductById(int id);

        public Task<BaseResponce<string>> AddProduct(Product newproduct);
        public Task<BaseResponce<string>> SaveProduct(Product newproduct);

        public Task<BaseResponce<List<SelectListItem>>> GetCountryList();
    }
}
