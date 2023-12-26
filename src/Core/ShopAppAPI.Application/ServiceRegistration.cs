using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ShopAppAPI.Application.Pipelines;

namespace ShopAppAPI.Application;

public static class ServiceRegistration
{
    public static void AddApplicationRegistration(this IServiceCollection serviceCollection)
    {
        var assembly = Assembly.GetExecutingAssembly();

        serviceCollection.AddAutoMapper(assembly);

        serviceCollection.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidatorBehavior<,>));
    }
}
