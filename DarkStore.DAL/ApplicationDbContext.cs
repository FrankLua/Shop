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
        public DbSet<Achievment> Achievment { get; set; }
        public DbSet<PicСarrier> ProductSrc { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }        
        public DbSet <FeedBack> feedback { get; set; }
        public DbSet <Role> Roles { get; set; }
        public DbSet<Basket> Basket { get; set; }
        
        
        
    }
}
