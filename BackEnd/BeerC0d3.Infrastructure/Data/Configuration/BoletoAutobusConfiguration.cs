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
    public class BoletoAutobusConfiguration : IEntityTypeConfiguration<BoletoAutobus>
    {
        public void Configure(EntityTypeBuilder<BoletoAutobus> builder)
        {
            builder.ToTable("BoletoAutobus", "Comite");
            builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(100);


            builder.Property(p => p.Precio)
          .IsRequired()
          .HasColumnType("decimal(18,2)");

            builder.Property(p => p.FechaAlta)
           .IsRequired()
           .HasColumnType("datetime");



        }

    }
}
