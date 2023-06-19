using System.Linq;
using System.Web;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DarkStore.Domain.ENUM;

namespace WebApplication6.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public Nullable<int> FullPrice { get; set; }
        public int StatusId { get; set; }
        [NotMapped]
        public StatusOrder status;

        public DateTime DataTimeAdd { get; set; }
        public Order() { StatusId = 1;DataTimeAdd = DateTime.Now; FullPrice = 0; }


    }

}
