using DarkStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.DAL.Interfaces
{
    public interface IFeedBackRep : IBaseInterface<string>
    {
        Task<string> AddFeedBack(FeedBack feedBack);
    }
}
