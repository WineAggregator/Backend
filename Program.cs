using Backend.Utils;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterAllServices();

builder.Configuration.AddJsonFile("Configs/appsettings.json");

var app = builder.Build();
app.RegisterAllMiddlewares();

app.Run();