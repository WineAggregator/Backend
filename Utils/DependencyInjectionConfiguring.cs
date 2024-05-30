using Backend.Api.Services;
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
        RegisterMyServices();
    }

    private static void RegisterAspServices()
    {
        _services.AddControllers();
        _services.AddEndpointsApiExplorer();
        _services.AddSwaggerGen();

        _services.AddDbContext<DatabaseContext>(options => options.UseNpgsql().UseLazyLoadingProxies());

        _services.AddHttpContextAccessor();
    }

    private static void RegisterRepositories()
    {
        _services.AddScoped<EventRepository>();
        _services.AddScoped<PhotoRepository>();
        _services.AddScoped<UserRepository>();
    }

    private static void RegisterMyServices()
    {
        _services.AddScoped<PhotoManager>();
    }
}
