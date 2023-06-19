using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;
using DarkStore.Domain.Entity;
using DarkStore.DAL.Interfaces;
using DarkStore.Service.Implementation;
using DarkStore.Service.Interfaces
    ;
using DarkStore.Domain.ENUM;
using DarkStore.Domain.Response;

namespace WebApplication6.Controllers
{
    public class PersonInfo : Controller
    {
        private readonly IOrderService _ordersService;
        private readonly IUserService _userService;
        public PersonInfo(IUserService userService, IOrderService ordersService)
        {
            _ordersService = ordersService;
            _userService = userService;
        }
        public async Task<IActionResult> PersonCabinet()
        {
            BaseResponce<User> user = await _userService.GetUserFindEmail(User.Identity.Name);

            return View(user.Data);

        }
        [HttpGet]
        public async Task<IActionResult> PersonEditor()
        {
            BaseResponce<User> user = await _userService.GetUserFindEmail(User.Identity.Name);

            return View(user.Data);
        }

        [HttpPost]

        public async Task<string> PersonEditor(EditorModel EditorModel)
        {
            BaseReponcefeedback Answer = await _userService.EditUser(EditorModel);


            if (Answer.StatusCode == DarkStore.Domain.ENUM.StatusCode.Ok) { return "Данные были изменены"; }
            else { return $"Данные не были изменены, ошибка{Answer.Description}"; }
        }

        
        public async Task<IActionResult> PersonBasket()
        {
            BaseResponce<User> user = await _userService.GetUserFindEmail(User.Identity.Name);
            
            return View(user.Data);

        }
        
        
        
        public async Task<IActionResult> OrderOk()
        {
            List<Basket> basketList = new List<Basket>();
            BaseResponce<User> user = await _userService.GetUserFindEmail(User.Identity.Name);
            BaseResponce<string> order = await _ordersService.AddOrder(user.Data);
    
            return View(order);
        }


    }
}
