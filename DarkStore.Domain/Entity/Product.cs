
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
        public  string Title { get; set; }
        
        [MaxLength(3)]
        [Display(Name = "Страна производитель")]
        public string CountryId { get; set; }
        
        [NotMapped]
        public virtual Country Country { get; set; }
        [Display(Name = "Краткое описание")]
        public string LiteDescription { get; set; }
        [Display(Name = "Подробная информация")]
        public string FullDescription { get; set; }
        

        public string SubPreview { get; set; }
        [Display(Name = "Количество")]
        public Nullable <int> Count { get ; set; }
        [Display(Name = "Цена")]
        public Nullable<int> Price { get; set; }
        
        [NotMapped]
        public virtual IFormFile Imgform { get; set; }



        public List<FeedBack> Productcomment { get; set; }
        public Product()
        {
            Productcomment = new List<FeedBack>();
        }


    }

}
