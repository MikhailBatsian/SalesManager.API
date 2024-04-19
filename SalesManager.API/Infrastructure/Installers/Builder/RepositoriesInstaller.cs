using SalesManager.Domain.Interfaces.Repositories;
using SalesManager.Persistence.Repositories;

namespace SalesManager.API.Infrastructure.Installers.Builder;

public static class RepositoriesInstaller
{
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISalesAmountRepository, SalesAmountAmountRepository>();
    }
}
