using Microsoft.EntityFrameworkCore;
using SalesManager.Domain.Dto;
using SalesManager.Domain.Entities;
using SalesManager.Domain.Filters;
using SalesManager.Domain.Interfaces.Repositories;
using SalesManager.Persistence.Extensions;

namespace SalesManager.Persistence.Repositories;

public class SalesAmountAmountRepository : EfRepository<SalesAmount>, ISalesAmountRepository
{
    private readonly SalesManagerDbContext _salesManagerDbContext;

    public SalesAmountAmountRepository(SalesManagerDbContext dbContext, SalesManagerDbContext salesManagerDbContext) : base(dbContext)
    {
        _salesManagerDbContext = salesManagerDbContext;
    }

    public IList<SalesAmountDto> GetSalesAmounts(SalesAmountFilter filter)
    {
        //DATEPART doesn't work with parameterisation, so use FromSqlRaw instead of FromSql
        var salesAmounts = _salesManagerDbContext.SalesAmount
            .FromSqlRaw(@$"
                SELECT 
                    DATEPART(year, [Date]) AS Year,
                    DATEPART({filter.TimeInterval.ToString().ToLower()}, [Date]) AS PeriodNumber,
                    SUM([Amount]) AS TotalAmount
                FROM [Sales]
                WHERE [Date] BETWEEN '{filter.StartDate:yyyy-MM-dd HH:mm:ss.fff}' AND '{filter.EndDate:yyyy-MM-dd HH:mm:ss.fff}'
                GROUP BY 
                    DATEPART(year, [Date]),
                    DATEPART({filter.TimeInterval.ToString().ToLower()}, [Date])
                ORDER BY Year, PeriodNumber
                OFFSET {filter.Skip} ROWS FETCH NEXT {filter.Take} ROWS ONLY")
           .ToList();

        var result = salesAmounts.Select(x => new SalesAmountDto
        {
            PeriodStartDate = x.ToPeriodStartDate(filter.TimeInterval),
            SalesAmount = x.TotalAmount
        }).ToList();
        
        return result;
    }
}
