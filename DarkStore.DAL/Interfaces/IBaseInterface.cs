using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.DAL.Interfaces
{
    public interface IBaseInterface<T>
    {
       Task<List<T>> GetObjects();
       Task<string> AddObject( T newproduct);
    }
}
