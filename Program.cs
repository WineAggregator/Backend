using Backend.Utils;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterAllServices();

var app = builder.Build();
app.RegisterAllMiddlewares();

app.Run();