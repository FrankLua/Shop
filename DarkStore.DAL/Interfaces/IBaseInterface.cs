using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.DAL.Interfaces
{
    public interface IBaseInterface<T>
    {
       IEnumerable<T> GetObjects();
    }
}
