using DarkStore.Domain.Entity;
using DarkStore.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.Service.Interfaces
{
    public interface IFeedBackService:IBaseResponse<FeedBack>
        
    {
        Task<BaseResponce<string>> AddFeedBack(FeedbackModel feedback);

        Task<BaseResponce<List<FeedBack>>> GetFeedbackId(int id);
    }
}
