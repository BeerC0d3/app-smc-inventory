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
    public class VentaMontoBoletoAutobusConfiguration : IEntityTypeConfiguration<VentaMontoBoletoAutobus>
    {
        public void Configure(EntityTypeBuilder<VentaMontoBoletoAutobus> builder)
        {
            builder.ToTable("VentaMontoBoletoAutobus", "Comite");
            builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Monto)
           .IsRequired()
           .HasColumnType("decimal(18,2)");

            builder.Property(p => p.FechaAlta)
           .IsRequired()
           .HasColumnType("datetime");

            builder.HasOne(p => p.VentaBoletoAutobus)
           .WithMany(p => p.VentaMontoBoletoAutobus)
           .HasForeignKey(p => p.VentaBoletoAutId);


        }
    }
}
