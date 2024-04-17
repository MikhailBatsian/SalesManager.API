using Microsoft.EntityFrameworkCore;
using SalesManager.API.Infrastructure.Installers.Builder;
using SalesManager.Persistence;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200");
        });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
