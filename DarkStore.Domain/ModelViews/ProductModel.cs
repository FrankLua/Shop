using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkStore.Domain.ModelViews
{
    public class ProductModel
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Title { get; set; }
        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        public string CountryId { get; set; }
        [Required]
        [MaxLength(70)]
        [MinLength(10)]
        public string LiteDescription { get; set; }
        [MaxLength(450)]
        public string FullDescription { get; set; }
        [Required]
        [Range(1, 500)]
        public Nullable<int> Count { get; set; }
        [Required]
        [Range(1, 999999)]
        public Nullable<int> Price { get; set; }
        [Required]
        public IFormFile Imgform { get; set; }
    }
}
