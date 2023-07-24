using DarkStore.DAL.Interfaces;
using DarkStore.Domain.Entity;
using DarkStore.Domain.Response;
using DarkStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.Service.Implementation
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IFeedBackRep _FeedbackRep;
        public FeedBackService(IFeedBackRep feedbackRep)
        {
            _FeedbackRep = feedbackRep;
        }
      
            

            public FeedBack Data => throw new NotImplementedException();

            public async Task<BaseResponce<string>> AddFeedBack(FeedbackModel feedback)
            {
            BaseResponce<string> baseResponce = new BaseResponce<string>();
            FeedBack feedbackfull = new FeedBack();
            try
            {

                FeedbackModel.FeedbackBuild(feedback, feedbackfull);
                baseResponce.Data = await _FeedbackRep.AddObject(feedbackfull);
                baseResponce.StatusCode = Domain.ENUM.StatusCode.Ok;
                baseResponce.Description = "";
                return baseResponce;
            }
            catch (Exception ex)
            {
                baseResponce.Data = ex.Message;
                baseResponce.StatusCode = Domain.ENUM.StatusCode.IternaServerError;
                baseResponce.Description = "";
                return baseResponce;

            }
        }

        public async Task<BaseResponce<List<FeedBack>>> GetFeedbackId(int id)
        {
            BaseResponce<List<FeedBack>> baseResponce = new BaseResponce<List<FeedBack>>();
            
            
            try
            {
                List<FeedBack> list1 = new List<FeedBack>();
                list1 = await _FeedbackRep.GetObjects();                
                list1.Where(x => x.UserId == id);
                baseResponce.Data = list1;
                baseResponce.StatusCode = Domain.ENUM.StatusCode.Ok;
                baseResponce.Description = "";
                return baseResponce;


            }
            catch (Exception ex)
            {
                baseResponce.Data = null;
                baseResponce.StatusCode = Domain.ENUM.StatusCode.IternaServerError;
                baseResponce.Description = "";
                return baseResponce;

            }
        }
    }
}
