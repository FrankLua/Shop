using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.Domain.Entity
{
    public class PicСarrier
    {
        public int Id { get; set; }
        public string Src{ get; set; }

        public int ProductId { get; set; }

        public int TypeId { get; set; }
        public int Couple { get; set; }
    }
}
