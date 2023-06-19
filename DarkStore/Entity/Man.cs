using System.Data;

namespace WebApplication6.Models
{
    public class Man
    {
        public int Id { get; set; }
        public  string title { get; set; }
        public string Type { get; set; }
        public string LiteDescription { get; set; }
        public string FullDescription { get; set; }
        public string SubPreview { get; set; }
        public Nullable <int> Count { get ; set; }
        public Nullable<int> Price { get; set; }

        

        public List<feedback> Productcomment { get; set; }
        public Man()
        {
            Productcomment = new List<feedback>();
        }


    }
    public class feedback
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NickName { get; set; }
        public bool Review { get; set; }    
        public string comments { get; set; }
        public DateTime data { get; set; }
        public int? ManId { get; set; }
        public string ProductName { get; set; }
    }
}
