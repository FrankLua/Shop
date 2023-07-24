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


namespace DarkStore.Service.Interfaces
{
    public interface IProductService

    {
        
        public Task<BaseResponce<List<Product>>> GetProducts();
        public Task<BaseResponce<Product>> GetProductById(int id);  
        

        
    }
}
