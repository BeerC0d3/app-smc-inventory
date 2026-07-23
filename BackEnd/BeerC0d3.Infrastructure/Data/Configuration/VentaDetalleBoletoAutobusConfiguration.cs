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
    public class VentaDetalleBoletoAutobusConfiguration : IEntityTypeConfiguration<VentaDetalleBoletoAutobus>
    {
        public void Configure(EntityTypeBuilder<VentaDetalleBoletoAutobus> builder)
        {
            builder.ToTable("VentaDetalleBoletoAutobus", "Comite");
            builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Precio)
           .IsRequired()
           .HasColumnType("decimal(18,2)");

            builder.Property(p => p.FechaAlta)
           .IsRequired()
           .HasColumnType("datetime");

            builder.HasOne(p => p.VentaBoletoAutobus)
           .WithMany(p => p.VentaDetalleBoletoAutobus)
           .HasForeignKey(p => p.VentaBoletoAutId);

            builder.HasOne(p => p.BoletoAutobus)
         .WithMany(p => p.VentaDetalleBoletos)
         .HasForeignKey(p => p.BoletoAutId);


        }
    }
}
