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
    public class VentaBoletoAutobusConfiguration : IEntityTypeConfiguration<VentaBoletoAutobus>
    {
        public void Configure(EntityTypeBuilder<VentaBoletoAutobus> builder)
        {
            builder.ToTable("VentaBoletoAutobus", "Comite");
            builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
                .IsRequired();


            //builder.Property(c => c.NombrePersona)
            //        .IsRequired()
            //        .HasColumnType("varchar")
            //        .HasMaxLength(100);



            builder.Property(p => p.FechaAlta)
           .IsRequired()
           .HasColumnType("datetime");

            builder.HasOne(p => p.Periodo)
           .WithMany(p => p.VentaBoletoAutobus)
           .HasForeignKey(p => p.PeriodoId);

            builder.HasOne(p => p.CatalogoDetalle)
               .WithMany(p => p.VentaBoletoAutobus)
               .HasForeignKey(p => p.EstatusId);

            builder.HasOne(p => p.Persona)
         .WithMany(p => p.VentaBoletoAutobus)
         .HasForeignKey(p => p.PersonaId);

        }
    }
}
