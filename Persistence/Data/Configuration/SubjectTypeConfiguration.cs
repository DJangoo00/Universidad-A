using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class SubjectTypeConfiguration : IEntityTypeConfiguration<SubjectType>
    {
        public void Configure(EntityTypeBuilder<SubjectType> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("subjectType");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            
        }
    }
}