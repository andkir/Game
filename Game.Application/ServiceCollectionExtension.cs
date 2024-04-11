using Game.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGameManager, GameManager>();
        
        return services;
    }
}
