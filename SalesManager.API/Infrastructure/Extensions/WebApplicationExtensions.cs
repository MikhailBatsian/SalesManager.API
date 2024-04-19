using SalesManager.API.Infrastructure.Middleware;

namespace SalesManager.API.Infrastructure.Extensions;

public static class WebApplicationExtensions
{
    public static void UseCorsPolicy(this WebApplication app)
    {
        var allowedOrigins = app.Configuration.GetValue<string>("Cors:AllowedOrigins");
        if (!string.IsNullOrEmpty(allowedOrigins))
        {
            var origins = allowedOrigins.Split(";");
            app.UseCors(x => x
                .WithOrigins(origins)
                .AllowAnyMethod()
                .AllowCredentials()
                .AllowAnyHeader());
        }
    }

    public static void UseExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
