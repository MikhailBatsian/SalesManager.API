using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesManager.Domain.Entities;

namespace SalesManager.Persistence.Configurations;

internal class SalesAmountConfiguration : IEntityTypeConfiguration<SalesAmount>
{
    public void Configure(EntityTypeBuilder<SalesAmount> builder)
    {
        builder.HasNoKey();
    }
}
