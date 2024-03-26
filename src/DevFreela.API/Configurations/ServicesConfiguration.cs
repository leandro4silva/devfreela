using DevFreela.Application.Commands.Projects.CreateProject;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;

namespace DevFreela.API.Configurations;

public static class ServicesConfiguration
{

    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(CreateCommand).Assembly));

        services.AddServices();

        return services;
    }

    public static IServiceCollection AddServices
        (this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISkillService, SkillService>();
        return services;
    }


}
