using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class SubjectRegisterConfiguration : IEntityTypeConfiguration<SubjectRegister>
    {
        public void Configure(EntityTypeBuilder<SubjectRegister> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("subjectRegister");

            builder.HasKey(t => new { t.IdStudentFk, t.IdSubjectFk, t.IdSchoolarCurseFk});

            builder.HasOne(p => p.Student)
            .WithMany(p => p.SubjectsRegisters)
            .HasForeignKey(p => p.IdStudentFk);

            builder.HasOne(p => p.Subject)
            .WithMany(p => p.SubjectsRegisters)
            .HasForeignKey(p => p.IdSubjectFk);

            builder.HasOne(p => p.SchoolarCurse)
            .WithMany(p => p.SubjectsRegisters)
            .HasForeignKey(p => p.IdSchoolarCurseFk);
        }
    }
}