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
        
        private readonly IUserService _userService;
        private readonly IAchievementService _achievementService;
        private readonly IBasketService _basketSevice;
        private readonly IFeedBackService _feedbackService;
        public PersonInfo(IFeedBackService feedbacks, IUserService userService,  IAchievementService achievementService, IBasketService basketService)
        {
            _feedbackService = feedbacks;
            
            _userService = userService;
            _achievementService = achievementService;
            _basketSevice = basketService;
        }
        public async Task<IActionResult> PersonCabinet()
        {
            if (User.Identity.Name != null)
            {
                BaseResponce<User> user = await _userService.GetUserFindEmail(User.Identity.Name);
                
                await _achievementService.UdateUserAchiwments(user.Data.Achievements, user.Data.Comments.Where(x => x.Review == 1).Count() , user.Data.Basket.Count);
                ViewBag.Atuntefication = true;
                return View(user.Data);
            }
            ViewBag.Atuntefication = false;
            return View();





        }
        [HttpGet]
        public async Task<IActionResult> PersonEditor()
        {
            BaseResponce<User> user = await _userService.GetUserFindEmail(User.Identity.Name);
            ViewBag.Email = user.Data.Email;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> PersonEditor(EditorModel EditorModel)
        {
            BaseResponce<string> Answer = new BaseResponce<string>();
            var responce = await _userService.GetUserFindEmail(EditorModel.Email);
            User oldUser = responce.Data;
            if (ModelState.IsValid)
            {
                
                Answer.Data = await _userService.EditUser(EditorModel, oldUser);
                return RedirectToAction("DarkStore", "Shop");
            }
            return View(EditorModel);


        }

        
        public async Task<IActionResult> UserBasket()
        {
            BaseResponce<User> user = await _userService.GetUserFindEmail(User.Identity.Name);
            BaseResponce<List<Basket>> list  = await _basketSevice.GetBasketbyId(user.Data.Id);
            
            return View(list.Data);

        }
        public async Task<IActionResult> AdminBasket()
        {
            BaseResponce<List<Basket>> list = await _basketSevice.GetBasket();

            return View(list.Data);

        }
        [HttpPost]
        public async Task<IActionResult> BasketUpdate(Basket basket)
        {
            if(ModelState.IsValid)
            {
               await  _basketSevice.UpdateBasket(basket);
            }
            

            return RedirectToAction("AdminBasket", "PersonInfo");

        }
        


        public async Task<IActionResult> FeedBackUser()
        {
           BaseResponce<User> user  = await _userService.GetUserFindEmail(User.Identity.Name);
            
            return View(user.Data.Comments);
        }
    }
}
