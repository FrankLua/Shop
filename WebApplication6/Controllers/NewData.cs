using DarkStore.Domain.Entity;
using DarkStore.Domain.ModelViews;
using DarkStore.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using WebApplication6.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication6.Controllers
{
    public class NewDataController : Controller
    {
        private readonly IProductService _productService;

        public NewDataController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize(Roles = "admin")]

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var responce = await _productService.GetProductById(id);
            var countries = await _productService.GetCountryList();
            IEnumerable<SelectListItem> country = countries.Data;
            ViewBag.Country = country;
            return View(responce.Data);

        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductModel newProduct)
        {
            if (ModelState.IsValid)
            {
                var responcebuild = await _productService.BuildProduct(newProduct);
                var responceanswer = await _productService.SaveProduct(responcebuild.Data);
                if (responceanswer.StatusCode == DarkStore.Domain.ENUM.StatusCode.Ok)
                {
                    return RedirectToAction("DarkStore", "Shop");
                }


            }
            var responce = await _productService.GetProductById(newProduct.Id);
            var countries = await _productService.GetCountryList();
            IEnumerable<SelectListItem> country = countries.Data;
            ViewBag.Country = country;
            return View(responce.Data);

        }


        [HttpGet]
        public async Task<IActionResult> NewProduct()
        {

            Product product = new Product();
            var countries = await _productService.GetCountryList();
            IEnumerable < SelectListItem > country = countries.Data;
            ViewBag.Country = country;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewProduct(ProductModel newProduct)
        {
            
            if (ModelState.IsValid)
            {
                var responcebuild = await _productService.BuildProduct(newProduct);
                var responceanswer = await _productService.AddProduct(responcebuild.Data);
                if(responceanswer.StatusCode == DarkStore.Domain.ENUM.StatusCode.Ok) 
                {
                    return RedirectToAction("DarkStore", "Shop");
                }
                else
                {
                    ModelState.AddModelError(nameof(newProduct.Title), responceanswer.Data);
                }
            }
            
            var countries = await _productService.GetCountryList();
            IEnumerable<SelectListItem> country = countries.Data;
            ViewBag.Country = country;
            return View();
        }
    }
}
