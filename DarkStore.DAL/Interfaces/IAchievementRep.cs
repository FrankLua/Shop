using DarkStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.DAL.Interfaces
{
    public interface IAchievementRep:IBaseInterface<Achievment>
    {
        public Task<List<Achievment>> GetAchievement(string userEmail);

        public Task  UpdateAchivement(Achievment achievment);
    }
}
