using Microsoft.EntityFrameworkCore;
using SalesManager.API;
using SalesManager.API.Infrastructure.Installers.Builder;
using SalesManager.API.Infrastructure.Middleware;
using SalesManager.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.AddRepositories();
builder.AddServices();

builder.Services.AddControllers();
builder.Services.AddDbContext<SalesManagerDbContext>(c =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    c.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure());
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Constants.MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(Constants.WebAppHost);
        });
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(Constants.MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/", () => Constants.AppStartText);

app.Run();
