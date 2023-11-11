using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class DepartamentConfiguration : IEntityTypeConfiguration<Departament>
    {
        public void Configure(EntityTypeBuilder<Departament> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("departament");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
        }
    }
}