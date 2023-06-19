using DarkStore.DAL.Interfaces;
using DarkStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.DAL.Repositories
{
    public class FeedBackRep : IFeedBackRep
    {
        private readonly ApplicationDbContext _Db;
        public FeedBackRep(ApplicationDbContext db)
        {
            _Db = db;
        }
        public async Task<string> AddFeedBack(FeedBack feedBack)
        {
            string answer = string.Empty;
            feedBack.Id = 0;
            _Db.feedback.Add(feedBack);
            _Db.SaveChanges();
            answer = "Данные были добавленны";
            return answer;
            
        }

        public IEnumerable<string> GetObjects()
        {
            throw new NotImplementedException();
        }
    }
}
