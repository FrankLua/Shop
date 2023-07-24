using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication6.Models;
using System.IO;
using DarkStore.Domain.Entity;
using System.Reflection;
using System.Diagnostics;
using DarkStore.Service.Interfaces;

namespace WebApplication6.Controllers
{
    public class LogController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAchievementService _achievementService;

        public LogController(IUserService userService, IAchievementService achievementService)
        {
            _userService = userService;
            _achievementService = achievementService;
              
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var number = await _userService.CheakNumber(model.PhoneNubmer);
                var user = await _userService.GetUserFindEmail(model.Email);

                if (user.Data != null && number.StatusCode == DarkStore.Domain.ENUM.StatusCode.Ok)
                {
                    await Authenticate(user.Data); // аутентификация

                    return RedirectToAction("DarkStore","Shop" );
                }
                ModelState.AddModelError(nameof(model.Email),"Пароль, номер телефона или имя пользователя не совпадают");
                ModelState.AddModelError(nameof(model.Password), "Пароль, номер телефона или имя пользователя не совпадают");
            }
            ModelState.AddModelError(nameof(model.Email), "Некорректные логин, номер и(или) пароль");
            ModelState.AddModelError(nameof(model.Password), "Некорректные логин, номер и(или) пароль");
            return View(model);
        }
        [HttpGet]
        public IActionResult Registred()
        {
            //RegisterModel model = new RegisterModel() {ConfirmPassword = "123123", Email = "43242342", Password = "123123", };
            //var answerAchi = await _achievementService.AddAchievement(model);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registred(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                
                var user = await _userService.GetUserFindEmail(model.Email);


                if (user.Data == null)
                {
                    var answer = await _userService.AddUser(model);                    
                    
                    if (answer.StatusCode == DarkStore.Domain.ENUM.StatusCode.Ok ) 
                    {
                        user = await _userService.GetUserFindEmail(model.Email);
                        Authenticate(user.Data); ; // аутентификация

                        return RedirectToAction("DarkStore", "Shop");
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(model.Email), answer.Data);
                    }                    


                }
                else
                    ModelState.AddModelError(nameof(model.Email), "Пользователь с таким емайлом уже зарегистрирован");
            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            string role = user.Role.Name;
            var claims = new List<Claim>
            {
                
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name),
    

        };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("DarkStore", "Shop");
        }
    }
}
