using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infra.Data.MapEntities
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Description)
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Image)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

            builder.Property(p => p.SalePrice)
              .HasColumnType("decimal(18,2)");

           


            builder.ToTable(nameof(Product));
        }
    }
}
