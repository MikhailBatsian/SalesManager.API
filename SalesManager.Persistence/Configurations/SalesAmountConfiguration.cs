using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesManager.Domain.Entities;

namespace SalesManager.Persistence.Configurations;

internal class SalesAmountConfiguration : IEntityTypeConfiguration<SalesData>
{
    public void Configure(EntityTypeBuilder<SalesData> builder)
    {
        builder.HasNoKey().ToView(null);

        builder.Property(x => x.TotalAmount)
            .HasColumnType("decimal(18,2)");
    }
}
