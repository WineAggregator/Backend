using Backend.Utils;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterAllServices();

builder.Configuration.AddJsonFile("Configs/appsettings.json");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();
app.RegisterAllMiddlewares();

app.UseCors(builder => builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());

await app.RunAsync();