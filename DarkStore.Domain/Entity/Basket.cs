using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.Domain.Entity
{
    public class Basket
    {

        public int Id { get; set; }
        public int UserId { get; set; }

        public int IdProduct { get; set; }
        [NotMapped]
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public bool Paid { get; set; }
        public Basket() 
        {
            OrderId = 0; Paid = false;
        }


    }
}
