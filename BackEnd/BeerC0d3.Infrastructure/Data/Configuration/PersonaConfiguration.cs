using BeerC0d3.Core.Entities.Comite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona", "Comite");
            builder.Property(p => p.Id)
                 .ValueGeneratedOnAdd()
                    .IsRequired();

            builder.Property(c => c.Nombre)
                  .IsRequired()
                  .HasColumnType("varchar")
                  .HasMaxLength(100);

            builder.Property(c => c.Colonia)
                 .HasColumnType("varchar")
                 .HasMaxLength(100);

            builder.Property(c => c.Calle)
               .HasColumnType("varchar")
               .HasMaxLength(100);

            builder.Property(c => c.Numero)
              .HasColumnType("varchar")
              .HasMaxLength(50);

            builder.Property(c => c.Latitud)
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(c => c.Longitud)
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(p => p.FechaAlta)
           .IsRequired()
           .HasColumnType("datetime");

            builder.HasOne(c => c.Seccion)
                  .WithMany(c => c.Personas)
                  .HasForeignKey(c => c.seccionId);
        }
    }
}
