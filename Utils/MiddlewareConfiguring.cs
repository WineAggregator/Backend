namespace Backend.Utils;

public static class MiddlewareConfiguring
{
    public static void RegisterAllMiddlewares(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
