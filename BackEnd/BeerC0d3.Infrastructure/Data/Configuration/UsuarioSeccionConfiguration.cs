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
    public class UsuarioSeccionConfiguration : IEntityTypeConfiguration<UsuarioSeccion>
    {
        public void Configure(EntityTypeBuilder<UsuarioSeccion> builder)
        {
            builder.ToTable("UsuarioSeccion", "Comite");
        }
    }
}
