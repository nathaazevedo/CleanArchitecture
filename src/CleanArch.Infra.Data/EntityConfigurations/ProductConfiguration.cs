using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200);
            builder.Property(p => p.Price).HasPrecision(10, 2).IsRequired();

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Coca-Cola",
                    Description = "2 litros",
                    Price = 9.99m
                },
                new Product
                {
                    Id = 2,
                    Name = "Guaraná",
                    Description = "Lata 330ml ",
                    Price = 2.99m
                }
            );
        }
    }
}
