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
    [Route("amounts")]
    public IEnumerable<SalesAmountDto> Get([FromQuery]SalesAmountFilter filter)
    {
        var result = _saleService.GetSalesAmounts(filter);

        return result;
    }
}
