using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopAppAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Persistance.Repositories;
using ShopAppAPI.Application.Repositories;

namespace ShopAppAPI.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceRegistration(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        serviceCollection.AddDbContext<ShopAppDbContext>(options
            => options.UseNpgsql(configuration["ConnectionStrings:SqlConnection"],
                                    options => options.EnableRetryOnFailure()));

        serviceCollection.AddTransient(typeof(IRepository<>), typeof(Repository<>));

        serviceCollection.AddTransient<IProductReadRepository, ProductReadRepository>();
        serviceCollection.AddTransient<IProductWriteRepository, ProductWriteRepository>();
    }

}
