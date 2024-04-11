using Game.Application.Repositories;
using Game.Application.Services;
using Game.Infrastructure.Configurations;
using Game.Infrastructure.ExternalServices;
using Game.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Game.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddGameInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
         var settings = configuration.GetSection(RandomizerServiceSettings.ConfigSectionName).Get<RandomizerServiceSettings>()!;
        
        services.AddScoped<IChoiceRepository, ChoiceRepository>();
        services.AddScoped<IGameRuleRepository, GameRuleRepository>();
        services.AddHttpClient<IChoiceRandomizer, ChoiceRandomizerService>(
            (serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(settings.Url);
                client.Timeout = TimeSpan.FromSeconds(settings.Timeout);
            }
        ).AddPolicyHandler(Utils.GetRetryPolicy(settings.RetryCount, settings.RetryDelay));

        return services;
    }
}
