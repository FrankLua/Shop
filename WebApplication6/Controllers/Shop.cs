using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication6.Models;
using DarkStore.Domain.Entity;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using DarkStore.Service.Interfaces;

namespace WebApplication6.Controllers
{
    public class Shop : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IFeedBackService _feedbacks;        
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        public Shop(IUserService userService,  IProductService productService, IBasketService basketService, IFeedBackService feedBack)
        {
            _feedbacks = feedBack;
            _productService = productService;
           
            _userService = userService;
            _basketService = basketService;
        }

        public async Task<IActionResult> DarkStore()
        {
            if (User.Identity.Name != null) 
            {
                var user = await _userService.GetUserFindEmail(User.Identity.Name);
                ViewBag.user = user.Data;
            }
            else
            {
                ViewBag.user = null;
            }   
            var products = await _productService.GetProducts();              
           

            return View(products.Data);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


       


        [HttpPost]
        public async Task<IActionResult> PageComent(FeedbackModel feedback)
        {
            if(ModelState.IsValid == true)
            {
                await _feedbacks.AddFeedBack(feedback);

            }

            return RedirectPermanent($"~/Shop/Page/{feedback.ProductId}");
        }

        
        public async Task<IActionResult> PageBuyNotAuntificate(BasketModel basket)
        {
            if (ModelState.IsValid == true)
            {
                await _basketService.AddBasket(basket);
                return RedirectPermanent($"~/Shop/DarkShop");

            }

            return RedirectPermanent($"~/Shop/Page/{basket.ProductId}");
        }


        [Authorize(Roles = "Клиент")]
        public async Task<IActionResult> PageBuyAuntificate(BasketModel basket)
        {
            if (ModelState.IsValid == true)
            {
                

            }

            return RedirectPermanent($"~/Shop/Page/{basket.ProductId}");
        }
        [HttpGet]
       public async Task<IActionResult> Page(int id)
       {
           if (User.Identity.Name != null)
           {
             var user = await _userService.GetUserFindEmail(User.Identity.Name);
             ViewBag.Role = user.Data.Role;
             ViewBag.user = user.Data;
                ViewBag.Aunteficated = true;
           }
           else
            { ViewBag.Aunteficated = false; }

           var product = await _productService.GetProductById(id);
           return View(product.Data);
       }

       
    }
}