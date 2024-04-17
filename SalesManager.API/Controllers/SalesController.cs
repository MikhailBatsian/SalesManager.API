using Microsoft.AspNetCore.Mvc;
using SalesManager.Domain.Dto;
using SalesManager.Domain.Filters;
using SalesManager.Domain.Interfaces.Services;

namespace SalesManager.API.Controllers;

[Route("api/sales")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;

    public SalesController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpGet]
    [Route("data")]
    public IEnumerable<SalesDataDto> GetSalesData([FromQuery]SalesDataFilter filter)
    {
        var result = _saleService.GetSalesAmounts(filter);

        return result;
    }

    [HttpGet]
    [Route("datacount")]
    public int GetSalesDataTotalCount([FromQuery] SalesDataFilter filter)
    {
        var result = _saleService.GetSalesDataTotalCount(filter);

        return result;
    }
}
