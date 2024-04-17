using SalesManager.Domain.Dto;
using SalesManager.Domain.Entities;
using SalesManager.Domain.Filters;

namespace SalesManager.Domain.Interfaces.Repositories;

public interface ISalesAmountRepository : IRepository<SalesAmount>
{
    IList<SalesAmountDto> GetSalesAmounts(SalesAmountFilter filter);
}
