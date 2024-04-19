using SalesManager.Domain.Entities;
using SalesManager.Domain.Enums;
using SalesManager.Persistence.Extensions;
using Xunit;

namespace SalesManager.UnitTests;

public class ExtensionsTests
{
    [Theory]
    [InlineData(TimeInterval.DayOfYear, 108, "2024-04-17 00:00:00.0000000")]
    [InlineData(TimeInterval.Week, 16, "2024-04-15 00:00:00.0000000")]
    [InlineData(TimeInterval.Month, 4, "2024-04-01 00:00:00.0000000")]
    [InlineData(TimeInterval.Quarter, 2, "2024-04-01 00:00:00.0000000")]
    public void ToPeriodStartDate_returns_start_date_of_time_interval_period_of_sale_data(TimeInterval inputTimeInterval, int inputPeriodNumber, DateTime expectedDate)
    {
        //Arrange
        var sut = new SalesData
        {
            PeriodNumber = inputPeriodNumber,
            Year = 2024
        };

        //Act
        var result = sut.ToPeriodStartDate(inputTimeInterval);

        //Assert
        Assert.Equal(expectedDate, result);
    }
}
