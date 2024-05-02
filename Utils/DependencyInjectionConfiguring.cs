using Backend.Database;

using Microsoft.EntityFrameworkCore;

namespace Backend.Utils;

public static class DependencyInjectionConfiguring
{
    private static IServiceCollection _services;

    public static void RegisterAllServices(this IServiceCollection services)
    {
        _services = services;

        RegisterAspServices();
    }

    private static void RegisterAspServices()
    {
        _services.AddControllers();
        _services.AddEndpointsApiExplorer();
        _services.AddSwaggerGen();

        _services.AddDbContext<DatabaseContext>(options => options.UseNpgsql());
    }
}
