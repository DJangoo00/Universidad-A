using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("teacher");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Person)
            .WithOne(p => p.Teacher)
            .HasForeignKey<Teacher>(p => p.IdPersonFk);

            builder.HasOne(p => p.Departament)
            .WithMany(p => p.Teachers)
            .HasForeignKey(p => p.IdDepartamentFk)
            .IsRequired(false);

        }
    }
}