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
    public class SeccionConfiguration : IEntityTypeConfiguration<Seccion>
    {
        public void Configure(EntityTypeBuilder<Seccion> builder)
        {
            builder.ToTable("Seccion", "Comite");
            builder.Property(p => p.Id)
                 .ValueGeneratedOnAdd()
                    .IsRequired();

            builder.Property(c => c.Nombre)
                  .IsRequired()
                  .HasColumnType("varchar")
                  .HasMaxLength(100);

            builder.Property(p => p.FechaAlta)
           .IsRequired()
           .HasColumnType("datetime");

            builder.Property(c => c.UsuarioAlta)
                 .IsRequired()
                 .HasColumnType("varchar")
                 .HasMaxLength(50);
        }
    }
}
