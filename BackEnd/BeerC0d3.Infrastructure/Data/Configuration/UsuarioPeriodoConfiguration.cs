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
    public class UsuarioPeriodoConfiguration : IEntityTypeConfiguration<UsuarioPeriodo>
    {
        public void Configure(EntityTypeBuilder<UsuarioPeriodo> builder)
        {
            builder.ToTable("UsuarioPeriodo", "Comite");
        }
    }
}
