using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonTypeConfiguration : IEntityTypeConfiguration<PersonType>
    {
        public void Configure(EntityTypeBuilder<PersonType> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("personType");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
        }
    }
}