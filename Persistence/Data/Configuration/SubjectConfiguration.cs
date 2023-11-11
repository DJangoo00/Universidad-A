using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Subject");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(e => e.Credits)
            .HasColumnType("float(7,2)")
            .IsRequired();

            builder.Property(e => e.Curse)
            .HasColumnType("tinyint")
            .IsRequired();

            builder.Property(e => e.Period)
            .HasColumnType("tinyint")
            .IsRequired();

            builder.HasOne(p => p.Teacher)
            .WithMany(p => p.Subjects)
            .HasForeignKey(p => p.IdTeacherFk)
            .IsRequired(false);

            builder.HasOne(p => p.Grade)
            .WithMany(p => p.Subjects)
            .HasForeignKey(p => p.IdGradeFk);

            builder.HasOne(p => p.SubjectType)
            .WithMany(p => p.Subjects)
            .HasForeignKey(p => p.IdSubjectTypeFk);
        }
    }
}