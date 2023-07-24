using DarkStore.DAL.Interfaces;
using DarkStore.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;
using DarkStore.Service.Interfaces;
using DarkStore.Service.Implementation;
using Microsoft.Extensions.Options;
using DarkStore;

namespace WebApplication6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
            builder.Services.AddControllersWithViews();
            IServiceCollection services = builder.Services;
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
            StartapInit.InitializerServices(services);
            StartapInit.InitializerRepositories(services);

            
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