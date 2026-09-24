using Microsoft.Extensions.DependencyInjection;

namespace Firmeza.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        //register here applications services
        return services;
    }
}