using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Configurations;

public static class DbContextConfigurations
{
    public static IServiceCollection AddDbContext
       (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DevfreelaDb");
        services.AddDbContext<DevFreelaDbContext>(options => options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            ));
        return services;
    }
}
