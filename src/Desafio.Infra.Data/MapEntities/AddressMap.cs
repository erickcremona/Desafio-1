using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infra.Data.MapEntities
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.PublicPlace)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Number)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.ZipCode)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(c => c.Complement)
                .HasColumnType("varchar(250)");

            builder.Property(c => c.District)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.City)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.State)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable(nameof(Address));
        }
    }
}
