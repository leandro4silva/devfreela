using DevFreela.Infrastructure.Persistence;

namespace DevFreela.API.Configurations;

public static class DbContextConfigurations
{
    public static IServiceCollection AddDbContext
       (this IServiceCollection services)
    {
        services.AddSingleton<DevFreelaDbContext>();
        return services;
    }
}
