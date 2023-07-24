using DarkStore.Domain.Response;
using DarkStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;
using DarkStore.Domain.Entity;
using DarkStore.DAL.Interfaces;

namespace DarkStore.Service.Implementation
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRep _AchievementRep;
        public AchievementService(IAchievementRep achievementRep)
        {
            _AchievementRep = achievementRep;
        }
        public Domain.Entity.Achievment Data => throw new NotImplementedException();

        public async Task<BaseResponce<string>> AddAchievement(RegisterModel newuser)
        {
            BaseResponce<string> answer = new BaseResponce<string>();
            try
            {
                var list = Achievment.AchievemetBuild(newuser);
                foreach (var item in list)
                {
                    answer.Data = await _AchievementRep.AddObject(item);
                }
                
                answer.StatusCode = Domain.ENUM.StatusCode.Ok;
                answer.Description = "";
                return  answer;

            }
            catch (Exception ex) 
            {
                answer.Data = "Ошибка!";
                answer.StatusCode = Domain.ENUM.StatusCode.Ok;
                answer.Description = ex.Message;
                return answer;
            }
        }

        public async Task<BaseResponce<string>> UdateUserAchiwments(List<Achievment> userachi, int countFeedback,int countBasket)
        {
            BaseResponce<string> answer = new BaseResponce<string>();
            try
            {
                foreach (Achievment item in userachi)
                {
                    if (item.progress < 100)
                    {
                        switch (item.typeId)
                        {
                            case 1:

                                {
                                    item.progress = ((int)(DateTime.Now - item.DateTime).TotalDays) * 10;
                                    if(item.progress >= 100)
                                    {
                                        item.DateTime = DateTime.Now;
                                    }
                                    break;
                                }
                            case 2:

                                {                                    
                                    item.progress = countFeedback * 10;
                                    if (item.progress >= 100)
                                    {
                                        item.DateTime = DateTime.Now;
                                    }
                                    break;
                                }
                            case 3:

                                {
                                    item.progress = countBasket * 10;
                                    if (item.progress >= 100)
                                    {
                                        item.DateTime = DateTime.Now;
                                    }
                                    break;
                                }

                        }
                        await  _AchievementRep.UpdateAchivement(item);
                    }

                }
                answer.Data = "Ok";
                answer.StatusCode= Domain.ENUM.StatusCode.Ok;
                answer.Description = "";
                return answer;

            }
            catch (Exception ex)
            {
                answer.Data = "Bad";
                answer.StatusCode = Domain.ENUM.StatusCode.Ok;
                answer.Description = ex.Message;
                return  answer;

            }
            
        }
    }
}
