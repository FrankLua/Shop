using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.Domain.Entity
{
    public class BasketModel
    {
        public int IdProduct { get; set; }
        public int UserId { get; set; }
        [Range(1, 50, ErrorMessage = "Минимальное количество должно быть не меньше 1, а максимальная не больше 50.")]
        public int Quantity { get; set; }
    }
}
