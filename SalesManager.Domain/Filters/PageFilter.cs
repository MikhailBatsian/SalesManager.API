namespace SalesManager.Domain.Filters;

public class PageFilter
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 50;
}
