using SalesManager.Domain.Dto;
using SalesManager.Domain.Entities;
using SalesManager.Domain.Filters;

namespace SalesManager.Domain.Interfaces.Repositories;

public interface ISalesAmountRepository : IRepository<SalesData>
{
    int GetSalesDataTotalCount(SalesDataFilter filter);
    IList<SalesDataDto> GetSalesData(SalesDataFilter filter);
}
