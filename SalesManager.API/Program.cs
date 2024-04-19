using Microsoft.EntityFrameworkCore;
using SalesManager.API;
using SalesManager.API.Infrastructure.Extensions;
using SalesManager.API.Infrastructure.Installers.Builder;
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

var app = builder.Build();

app.UseExceptionHandler();
app.UseCorsPolicy();
app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/", () => Constants.AppStartText);

app.Run();
