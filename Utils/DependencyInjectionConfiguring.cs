using Backend.Api.Services;
using Backend.Api.Services.Filters;
using Backend.Api.Services.ModelBinders;
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
        _services.AddControllers(options => options.ModelBinderProviders.Insert(0, new AuthorizationHeaderModelBinderProvider()));
        _services.AddEndpointsApiExplorer();

        _services.AddHttpContextAccessor();

        _services.AddSwaggerGen(c => c.OperationFilter<SwaggerAuthorizationHeaderFilter>());
        _services.AddDbContext<DatabaseContext>(options => options.UseNpgsql().UseLazyLoadingProxies());

        _services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    }

    private static void RegisterRepositories()
    {
        _services.AddScoped<EventRepository>();
        _services.AddScoped<PhotoRepository>();
        _services.AddScoped<UserRepository>();
        _services.AddScoped<TicketRepository>();
        _services.AddScoped<EventPhotoRepository>();
    }

    private static void RegisterMyServices()
    {
        _services.AddScoped<PhotoManager>();
    }
}
