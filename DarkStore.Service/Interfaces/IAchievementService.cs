using DarkStore.Domain.Entity;
using DarkStore.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.Service.Interfaces
{
    public interface IAchievementService:IBaseResponse<Achievment>
    {
        public  Task<BaseResponce<string>> AddAchievement(RegisterModel newuser);

        public Task<BaseResponce<string>> UdateUserAchiwments(List<Achievment> userachi,int countComment,int countBasket);
    }
}
