using SalesManager.Domain.Interfaces.Services;
using SalesManager.Domain.Services;

namespace SalesManager.API.Infrastructure.Installers.Builder;

public static class ServicesInstaller
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISaleService, SaleService>();
    }
}
