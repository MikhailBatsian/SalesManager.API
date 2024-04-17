using SalesManager.Domain.Dto;
using SalesManager.Domain.Filters;
using SalesManager.Domain.Interfaces.Repositories;
using SalesManager.Domain.Interfaces.Services;

namespace SalesManager.Domain.Services;
public class SaleService : ISaleService
{
    private readonly ISalesAmountRepository _salesAmountRepository;

    public SaleService(ISalesAmountRepository salesAmountRepository)
    {
        _salesAmountRepository = salesAmountRepository;
    }

    public IList<SalesAmountDto> GetSalesAmounts(SalesAmountFilter filter)
    {
        return _salesAmountRepository.GetSalesAmounts(filter);
    }
}
