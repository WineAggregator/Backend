using Backend.Database;
using Backend.Database.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Backend.Utils;

public static class DependencyInjectionConfiguring
{
    private static IServiceCollection _services;

    public static void RegisterAllServices(this IServiceCollection services)
    {
        _services = services;

        RegisterAspServices();
        RegisterRepositories();
    }

    private static void RegisterAspServices()
    {
        _services.AddControllers();
        _services.AddEndpointsApiExplorer();
        _services.AddSwaggerGen();

        _services.AddDbContext<DatabaseContext>(options => options.UseNpgsql().UseLazyLoadingProxies());
    }

    private static void RegisterRepositories()
    {
        _services.AddScoped<EventRepository>();
    }
}
