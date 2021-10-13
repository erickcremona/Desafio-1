using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infra.Data.MapEntities
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category)).HasKey(c => c.Id);

            builder.Property(p => p.Name)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(p => p.Profit)
              .HasColumnType("float")
              .IsRequired();


        }
    }
}
