using DarkStore.Domain.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.Domain.Response
{
    public class BaseResponce <T> : IBaseResponse <T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
    public interface IBaseResponse <T>
    {
        T Data { get; }
            

    }    
}
