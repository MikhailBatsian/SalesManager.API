using Microsoft.EntityFrameworkCore;
using SalesManager.Domain.Dto;
using SalesManager.Domain.Entities;
using SalesManager.Domain.Filters;
using SalesManager.Domain.Interfaces.Repositories;
using SalesManager.Persistence.Extensions;

namespace SalesManager.Persistence.Repositories;

public class SalesAmountAmountRepository : EfRepository<SalesData>, ISalesAmountRepository
{
    private readonly SalesManagerDbContext _salesManagerDbContext;

    public SalesAmountAmountRepository(SalesManagerDbContext salesManagerDbContext) : base(salesManagerDbContext)
    {
        _salesManagerDbContext = salesManagerDbContext;
    }

    public int GetSalesDataTotalCount(SalesDataFilter filter)
    {
        var result = GetSalesDataQuery(filter, usePaging:false).Count();

        return result;
    }

    public IList<SalesDataDto> GetSalesData(SalesDataFilter filter)
    {
        var salesData = GetSalesDataQuery(filter).ToList();

        var result = salesData.Select(x => new SalesDataDto
        {
            Count = x.Count,
            PeriodStartDate = x.ToPeriodStartDate(filter.TimeInterval),
            SalesAmount = x.TotalAmount
        }).ToList();

        return result;
    }

    private IQueryable<SalesData> GetSalesDataQuery(SalesDataFilter filter, bool usePaging = true)
    {
        var sqlFunction = @$"
                    SELECT 
                        DATEPART(year, Date) AS Year,
                        DATEPART({filter.TimeInterval.ToString().ToLower()}, Date) AS PeriodNumber,
                        SUM(Amount) AS TotalAmount,
                        Count(Amount) As Count
                    FROM Sales
                    WHERE Date BETWEEN '{filter.StartDate.ToString(Constants.DateTimeFormat)}' AND '{filter.EndDate.ToString(Constants.DateTimeFormat)}'
                    GROUP BY 
                        DATEPART(year, Date),
                        DATEPART({filter.TimeInterval.ToString().ToLower()}, Date)";

        if (usePaging)
        {
            sqlFunction = string.Concat(sqlFunction, $"ORDER BY Year, PeriodNumber OFFSET {filter.Skip} ROWS FETCH NEXT {filter.Take} ROWS ONLY");
        }

        //DATEPART doesn't work with parameterisation, so use FromSqlRaw instead of FromSql
        return _salesManagerDbContext.SalesAmount.FromSqlRaw(sqlFunction);
    }
}
