using DarkStore.DAL.Interfaces;
using DarkStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
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
        public async Task<string> AddObject(FeedBack feedBack)
        {                      
            _Db.feedback.Add(feedBack);
            _Db.SaveChanges();            
            return "Данные были добавленны";            
        }

        public async Task<List<FeedBack>> GetObjects(int id)
        {

            List<FeedBack> List = new List<FeedBack>();
                
            List = await _Db.feedback.ToListAsync();
            return List;


        }

        public async Task<List<FeedBack>> GetObjects()
        {
            List<FeedBack> List = new List<FeedBack>();

            List = await _Db.feedback.ToListAsync();
            return List;
        }
    }
}
