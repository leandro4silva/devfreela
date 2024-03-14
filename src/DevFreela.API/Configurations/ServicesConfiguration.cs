using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.API.Configurations;

public static class ServicesConfiguration
{
    public static IServiceCollection AddServices
        (this IServiceCollection services)
    {
        services.AddScoped<IProjectService, ProjectService>();
        return services;
    }


}
