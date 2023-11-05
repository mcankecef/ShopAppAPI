using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopAppAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Persistance.Repositories;
using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Application;
using ShopAppAPI.Domain;
using Microsoft.AspNetCore.Identity;

namespace ShopAppAPI.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceRegistration(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        serviceCollection.AddDbContext<ShopAppDbContext>(options
            => options.UseSqlServer(configuration["ConnectionStrings:SqlConnection"],
                                    options => options.EnableRetryOnFailure()));

        serviceCollection.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true;
            //options.User.AllowedUserNameCharacters 
        }).AddEntityFrameworkStores<ShopAppDbContext>();

        serviceCollection.AddTransient(typeof(IRepository<>), typeof(Repository<>));

        serviceCollection.AddTransient<IProductReadRepository, ProductReadRepository>();
        serviceCollection.AddTransient<IProductWriteRepository, ProductWriteRepository>();

        serviceCollection.AddTransient<IBasketWriteRepository, BasketWriteRepository>();
        serviceCollection.AddTransient<IBasketReadRepository, BasketReadRepository>();

        serviceCollection.AddTransient<IUserService, UserService>();
    }

}
