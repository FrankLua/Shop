using Microsoft.EntityFrameworkCore;
using DarkStore.Domain.Entity;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using DarkStore.Domain.ENUM;

namespace WebApplication6.Models
{

    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet <FeedBack> feedback { get; set; }
        public DbSet <Role> Roles { get; set; }
        public DbSet<Basket> Basket { get; set; }

        public DbSet<Country> Country { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Country country1 = new Country { Code = "RUS", Name = "Россия" };
            Country country2 = new Country { Code = "EFI", Name = "Эфиопия" };
            Country country3 = new Country { Code = "AME", Name = "Америка" };
            Country country4 = new Country { Code = "EUR", Name = "Европа" };
            Country country5= new Country { Code = "CHI", Name = "Китай" };
            Country country6 = new Country { Code = "JAP", Name = "Япония" };
            modelBuilder.Entity<Country>().HasData(new Country[] { country1, country2, country3, country4, country5, country6 });            
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
