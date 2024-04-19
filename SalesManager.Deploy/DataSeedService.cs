using SalesManager.Domain.Entities;
using SalesManager.Persistence;

namespace SalesManager.Deploy;

public class DataSeedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public DataSeedService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public Task SeedDataAsync()
    {
        return AddFakeSales();
    }

    private async Task AddFakeSales()
    {
        await using var scope = _serviceScopeFactory.CreateAsyncScope();
        var scopeServiceProvider = scope.ServiceProvider;
        var context = scopeServiceProvider.GetService<SalesManagerDbContext>();
        var exist = context.Sales.Any();
        
        if (exist) return;

        var random = new Random();
        var saleDate = new DateTime(2020, 1, 1);

        for (var i = 0; i < 1000; i++)
        {
            saleDate = saleDate.AddDays(1);
            var salesCount = random.Next(1, 20);
            for (int j = 0; j < salesCount; j++)
            {
                var sale = new Sale
                {
                    Amount = random.Next(100, 1001),
                    Date = saleDate
                };

                context.Add(sale);
            }

        }
            
        await context.SaveChangesAsync();
    }
}