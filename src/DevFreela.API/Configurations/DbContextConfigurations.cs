using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.API.Configurations;

public static class DbContextConfigurations
{
    public static IServiceCollection AddDbContext
       (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DevfreelaDb");
        services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));
        return services;
    }
}
