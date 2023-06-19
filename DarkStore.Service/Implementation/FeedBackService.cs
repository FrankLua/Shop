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

            public async Task<BaseResponce<string>> AddFeedBack(FeedBack feedback)
            {
            BaseResponce<string> baseResponce = new BaseResponce<string>();
            try
            {
                baseResponce.Data = await _FeedbackRep.AddFeedBack(feedback);
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
        
 
      
    }
}
