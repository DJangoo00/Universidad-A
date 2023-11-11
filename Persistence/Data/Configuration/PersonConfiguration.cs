using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("person");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.DNI)
            .HasColumnType("varchar")
            .HasMaxLength(10)
            .IsRequired();

            builder.Property(e => e.FirstName)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(e => e.LastName1)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(e => e.LastName2)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(e => e.City)
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();
            
            builder.Property(e => e.Adress)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(e => e.Telephone)
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(e => e.Birthday)
            .HasColumnType("date")
            .IsRequired();

            builder.HasOne(p => p.Gender)
            .WithMany(p => p.Persons)
            .HasForeignKey(p => p.IdGenderFk);

            builder.HasOne(p => p.PersonType)
            .WithMany(p => p.Persons)
            .HasForeignKey(p => p.IdPersonTypeFk);
        }
    }
}