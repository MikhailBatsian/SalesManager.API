using SalesManager.Domain.Dto;
using SalesManager.Domain.Filters;

namespace SalesManager.Domain.Interfaces.Services;

public interface ISaleService
{
    IList<SalesAmountDto> GetSalesAmounts(SalesAmountFilter filter);
}
