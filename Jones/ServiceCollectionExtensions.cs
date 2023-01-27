using System.Text.Json;
using Jones.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Jones;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJonesService(this IServiceCollection services)
    {
        services.AddSingleton<IJsonSerializer, JsonSerializerImpl>();

        return services;
    }
    
    public static IServiceProvider UseJonesService(this IServiceProvider serviceProvider, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        jsonSerializerOptions ??= serviceProvider.GetService<IOptions<JsonSerializerOptions>>()?.Value;
        if (jsonSerializerOptions != null)
        {
            JsonConfig.Set(jsonSerializerOptions);
        }
        
        return serviceProvider;
    }
}