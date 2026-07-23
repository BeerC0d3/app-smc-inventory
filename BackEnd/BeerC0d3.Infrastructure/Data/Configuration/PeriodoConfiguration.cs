using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Entities.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Data.Configuration
{
    public class PeriodoConfiguration : IEntityTypeConfiguration<Periodo>
    {
        public void Configure(EntityTypeBuilder<Periodo> builder)
        {
            builder.ToTable("Periodo", "Comite");
            builder.Property(c => c.Id)
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


            builder.HasOne(p => p.CatalogoDetalle)
                  .WithMany(p => p.Periodos)
                  .HasForeignKey(p => p.EstatusId);

        }
    }
}
