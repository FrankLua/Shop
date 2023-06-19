using DarkStore.DAL.Interfaces;
using DarkStore.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;
using DarkStore.Service.Interfaces;
using DarkStore.Service.Implementation;
using Microsoft.Extensions.Options;

namespace WebApplication6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => //CookieAuthenticationOptions
               {
                   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Home/Index");
               });
            
            
            builder.Services.AddDbContext<ApplicationDbContext>(optionsAction: options =>
            {
                options.LogTo(Console.WriteLine);
                options.UseSqlServer(connectionString);
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("DarkStore"));
            });
            builder.Services.AddScoped<IUserRep, UserRep>();
            builder.Services.AddScoped<IOrderRep, OrderRep>();
            builder.Services.AddScoped<IProductRep, ProductRep>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IBasketService,BasketService>();
            builder.Services.AddScoped<IBasketRep, BasketRep>();
            builder.Services.AddScoped<IFeedBackRep, FeedBackRep>();
            builder.Services.AddScoped<IFeedBackService, FeedBackService>();
            
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();    
            app.UseAuthorization();     

            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Shop}/{action=DarkStore}/{id?}");

            app.Run();
        }
    }
}