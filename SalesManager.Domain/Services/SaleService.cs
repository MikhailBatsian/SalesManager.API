﻿using SalesManager.Domain.Dto;
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

    public int GetSalesDataTotalCount(SalesDataFilter filter)
    {
        return _salesAmountRepository.GetSalesDataTotalCount(filter);
    }

    public IList<SalesDataDto> GetSalesAmounts(SalesDataFilter filter)
    {
        return _salesAmountRepository.GetSalesData(filter);
    }
}
