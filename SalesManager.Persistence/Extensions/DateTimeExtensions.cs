using SalesManager.Domain.Entities;
using SalesManager.Domain.Enums;

namespace SalesManager.Persistence.Extensions;
internal static class DateTimeExtensions
{
    public static DateTime ToPeriodStartDate(this SalesData salesData, TimeInterval timeInterval)
    {
        var yearStartDate = new DateTime(salesData.Year, 1, 1);
        switch (timeInterval)
        {
            case TimeInterval.DayOfYear:
                return yearStartDate.AddDays(salesData.PeriodNumber - 1);

            case TimeInterval.Week:
                var firstWeekDate = yearStartDate.StartOfWeek(DayOfWeek.Monday).AddDays(-7);
                return firstWeekDate.AddDays(salesData.PeriodNumber * 7);
                
            case TimeInterval.Month:
                return new DateTime(salesData.Year, salesData.PeriodNumber, 1);

            case TimeInterval.Quarter:
                var previousQuarter = yearStartDate.AddMonths(-3);
                return previousQuarter.AddMonths(salesData.PeriodNumber * 3);

            default:
                throw new ArgumentOutOfRangeException(nameof(timeInterval), timeInterval, null);
        }
    }

    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
        var diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(-1 * diff).Date;
    }
}
