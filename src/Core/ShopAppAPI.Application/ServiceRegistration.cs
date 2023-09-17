using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ShopAppAPI.Application;

public static class ServiceRegistration
{
    public static void AddApplicationRegistration (this IServiceCollection serviceCollection){
        var assembly = Assembly.GetExecutingAssembly();
        
        serviceCollection.AddAutoMapper(assembly);
        serviceCollection.AddMediatR(assembly);
    }

}
