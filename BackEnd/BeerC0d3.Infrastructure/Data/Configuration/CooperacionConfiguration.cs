using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Entities.Sistema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Data.Configuration
{
    public class CooperacionConfiguration: IEntityTypeConfiguration<Cooperacion>
    {
        public void Configure(EntityTypeBuilder<Cooperacion> builder)
        {
            builder.ToTable("Cooperacion", "Comite");
            builder.Property(c => c.Id)
               .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(p => p.Monto)
              .IsRequired()
              .HasColumnType("decimal(18,2)");

            builder.Property(p => p.FechaAlta)
           .IsRequired()
           .HasColumnType("datetime");

            builder.HasOne(p => p.Periodo)
              .WithMany(p => p.Cooperaciones)
              .HasForeignKey(p => p.PeriodoId);

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.Cooperaciones)
            .HasForeignKey(p => p.PersonaId);


        }
    }
}
