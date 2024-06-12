using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stroymarket_net_api.Entities;

namespace stroymarket_net_api.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
    builder.Property(product => product.Price).HasPrecision(5, 2);
    }
}