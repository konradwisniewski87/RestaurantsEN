using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        var applicationAssemblyName = typeof(ServiceCollectionExtensions).Assembly;  
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssemblyName));
        services.AddAutoMapper(applicationAssemblyName);
        services.AddValidatorsFromAssembly(applicationAssemblyName)
            .AddFluentValidationAutoValidation();
    }
}
