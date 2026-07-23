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
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "Seguridad");
            builder.Property(p => p.Id)
                    .IsRequired();
            builder.Property(p => p.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(200);
            builder.Property(p => p.ApellidoPaterno)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(200);
            builder.Property(p => p.ApellidoMaterno)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasMaxLength(200);

            builder.Property(p => p.Username)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
            builder.Property(p => p.Email)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

            builder.Property(p => p.FotoUrl)
                   .HasColumnType("varchar")
                   .HasMaxLength(600);

            builder.Property(p => p.FechaRegistro)
             .HasColumnType("datetime");

            builder.Property(p => p.FechaActivacion)
              .HasColumnType("datetime");

            builder.Property(p => p.CodigoActivacion)
                   .HasColumnType("varchar")
                   .HasMaxLength(200);

            builder
            .HasMany(p => p.Roles)
            .WithMany(p => p.Usuarios)
            .UsingEntity<UsuariosRoles>(
                j => j
                    .HasOne(pt => pt.Rol)
                    .WithMany(t => t.UsuariosRoles)
                    .HasForeignKey(pt => pt.RolId),
                j => j
                    .HasOne(pt => pt.Usuario)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(pt => pt.UsuarioId),
                j =>
                {
                    j.HasKey(t => new { t.UsuarioId, t.RolId });
                });

            builder.HasMany(p => p.RefreshTokens)
             .WithOne(p => p.Usuario)
             .HasForeignKey(p => p.UsuarioId);

            builder
           .HasMany(p => p.Secciones)
           .WithMany(p => p.Usuarios)
           .UsingEntity<UsuarioSeccion>(
               j => j
                   .HasOne(pt => pt.Seccion)
                   .WithMany(t => t.UsuarioSecciones)
                   .HasForeignKey(pt => pt.SeccionId),
               j => j
                   .HasOne(pt => pt.Usuario)
                   .WithMany(p => p.UsuarioSecciones)
                   .HasForeignKey(pt => pt.UsuarioId),
               j =>
               {
                   j.HasKey(t => new { t.UsuarioId, t.SeccionId });
               });

            builder
          .HasMany(p => p.Periodos)
          .WithMany(p => p.Usuarios)
          .UsingEntity<UsuarioPeriodo>(
              j => j
                  .HasOne(pt => pt.Periodo)
                  .WithMany(t => t.UsuarioPeriodos)
                  .HasForeignKey(pt => pt.PeriodoId),
              j => j
                  .HasOne(pt => pt.Usuario)
                  .WithMany(p => p.UsuarioPeriodos)
                  .HasForeignKey(pt => pt.UsuarioId),
              j =>
              {
                  j.HasKey(t => new { t.UsuarioId, t.PeriodoId });
              });
        }
    }
      
}
