using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.Domain.Entity
{
    public class FeedBack
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NickName { get; set; }
        public bool Review { get; set; }
        public string Comments { get; set; }
        public DateTime Data { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public FeedBack() { Id = 0; Data = DateTime.Now; }
    }

}
