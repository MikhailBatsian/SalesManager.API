using SalesManager.Domain.Enums;

namespace SalesManager.Domain.Filters;

public class SalesDataFilter : PageFilter
{
    public TimeInterval TimeInterval { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
