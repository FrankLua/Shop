using DarkStore.DAL.Interfaces;
using DarkStore.DAL.Repositories;
using DarkStore.Service.Implementation;
using DarkStore.Service.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DarkStore
{
    public static class StartapInit
    {
        public static void InitializerServices (this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IFeedBackService, FeedBackService>();
            services.AddScoped<IAchievementService, AchievementService>();
        }
        public static void InitializerRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRep, UserRep>();
            
            services.AddScoped<IProductRep, ProductRep>();
            services.AddScoped<IBasketRep, BasketRep>();
            services.AddScoped<IFeedBackRep, FeedBackRep>();
            services.AddScoped<IAchievementRep, AchievementRep>();
        }
    }
}
