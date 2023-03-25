using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}