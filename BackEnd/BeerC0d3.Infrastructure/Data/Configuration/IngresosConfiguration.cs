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
    public class IngresosConfiguration : IEntityTypeConfiguration<Ingresos>
    {
        public void Configure(EntityTypeBuilder<Ingresos> builder)
        {
            builder.ToTable("Ingresos", "Comite");

            builder.Property(p => p.Id)
                 .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Monto)
          .IsRequired()
          .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Descripcion)
                 .HasColumnType("varchar")
                 .HasMaxLength(200);


            builder.Property(p => p.FechaAlta)
           .IsRequired()
           .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
        .IsRequired()
        .HasColumnType("datetime");

            builder.Property(c => c.UsuarioModificacion)
                 .IsRequired()
                 .HasColumnType("varchar")
                 .HasMaxLength(50);

            builder.HasOne(p => p.Periodo)
              .WithMany(p => p.Ingresos)
              .HasForeignKey(p => p.PeriodoId);

            builder.HasOne(p => p.CatalogoDetalle)
                .WithMany(p => p.Ingresos)
                .HasForeignKey(p => p.ConcentoId);
        }
    }

}
