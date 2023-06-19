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
        private readonly IOrderService _ordersService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        public Shop(IUserService userService, IOrderService ordersService, IProductService productService, IBasketService basketService, IFeedBackService feedBack)
        {
            _feedbacks = feedBack;
            _productService = productService;
            _ordersService = ordersService;
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
           
        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IActionResult> Buy(int id)
        {
            var user = await _userService.GetUserFindEmail(User.Identity.Name);
            ViewBag.user = user.Data;
            var product = await _productService.GetProductById(id);
            ViewBag.product = product.Data;  
           return View();
        }
         
        [HttpPost]
        
        public async Task<IActionResult> Buy(BasketModel basketModel)
        {
            Basket basket = new Basket();
            if (ModelState.IsValid)
            {
                var productbasket = await _productService.GetProductById(basketModel.IdProduct);
                var responceBasket = await _basketService.BuildBasket(basketModel, productbasket.Data);
                Basket Basket = responceBasket.Data;
                _basketService.AddBasket(Basket);
                return RedirectToAction("PersonBasket", "PersonInfo");
            }
            else
            {
                var user = await _userService.GetUserFindEmail(User.Identity.Name);
                ViewBag.user = user.Data;
                var product = await _productService.GetProductById(basketModel.IdProduct);
                ViewBag.product = product.Data;
            }

            return View(basketModel);

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
        [HttpPost]
        public async Task<IActionResult> Page(FeedBack feedback )
       {
            
            
             var responce = await _feedbacks.AddFeedBack(feedback);
           
           return RedirectToAction("Page","Shop") ;
       }
       
    }
}