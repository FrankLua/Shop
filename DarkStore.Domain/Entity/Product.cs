
using DarkStore.Domain.Entity;
using DarkStore.Domain.ENUM;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication6.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Имя")]
        public  string Name { get; set; }
        
      

        [Display(Name = "Краткое описание")]
        public string LiteDescription { get; set; }

        

        public string SubPreview { get; set; }
        [Display(Name = "Количество")]

        [NotMapped]
        public List<FeedBack> Productcomment { get; set; }

        [NotMapped]
        public List<PicСarrier> ProductPic { get ; set; }
        public Product()
        {
            Productcomment = new List<FeedBack>();    
            
            ProductPic = new List<PicСarrier>();   
        }
        

    }

}
