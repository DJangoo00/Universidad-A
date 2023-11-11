using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class SchoolarCurseConfiguration : IEntityTypeConfiguration<SchoolarCurse>
    {
        public void Configure(EntityTypeBuilder<SchoolarCurse> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("schoolarCurse");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Start)
            .HasColumnType("year")
            .IsRequired();

            builder.Property(e => e.Start)
            .HasColumnType("year")
            .IsRequired();
        }
    }
}