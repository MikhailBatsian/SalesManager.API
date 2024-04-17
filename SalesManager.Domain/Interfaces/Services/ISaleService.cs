using SalesManager.Domain.Dto;
using SalesManager.Domain.Filters;

namespace SalesManager.Domain.Interfaces.Services;

public interface ISaleService
{
    int GetSalesDataCount(SalesDataFilter filter);
    IList<SalesDataDto> GetSalesAmounts(SalesDataFilter filter);
}
