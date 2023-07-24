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
    public class AchievementRep : IAchievementRep
    {
        private readonly ApplicationDbContext _Db;
        public AchievementRep(ApplicationDbContext db)
        {
            _Db = db;
        }
        public async Task<string> AddObject(Achievment newAchiv)
        {
            var item = _Db.Achievment.Add(newAchiv);
            await _Db.SaveChangesAsync();
            return "Ok";
        }

        public Task<List<Achievment>> GetAchievement(string userEmail)
        {

            throw new NotImplementedException();
        }       

        public Task<List<Achievment>> GetObjects()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAchivement(Achievment achievment)
        {
              _Db.Achievment.Update(achievment);
            await _Db.SaveChangesAsync();
        }
    }
}
