using Microsoft.EntityFrameworkCore;
using SalesManager.Persistence;

namespace SalesManager.Deploy;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<SalesManagerDbContext>(options =>
        {
            options.UseSqlServer(_configuration.GetConnectionString("Database"));
        });

        services.AddScoped<DataSeedService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }
}