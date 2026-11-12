
using MES.Application.Abstractions;
using MES.Infrastructure.Time;
using Microsoft.Extensions.DependencyInjection;

namespace MES.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<IClock, SystemClock>();
        return services;
    }
}
