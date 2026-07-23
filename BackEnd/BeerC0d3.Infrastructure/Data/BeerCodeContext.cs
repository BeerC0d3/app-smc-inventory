using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Entities.Seguridad;
using BeerC0d3.Core.Entities.Sistema;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Data
{
    public class BeerCodeContext:DbContext
    {
        public BeerCodeContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<CatalogoDetalle> CatalogoDetalles { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<UsuarioSeccion> UsuarioSecciones { get; set; }
        public DbSet<UsuarioPeriodo> UsuarioPeriodos { get; set; }
        public DbSet<Ingresos> Ingresos { get; set; }
        public DbSet<Egresos> Egresos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cooperacion> Cooperaciones { get; set; }
        public DbSet<BoletoAutobus> BoletoAutobus { get; set; }
        public DbSet<VentaBoletoAutobus> VentaBoletoAutobus { get; set; }
        public DbSet<VentaMontoBoletoAutobus> VentaMontoBoletoAutobus { get; set; }
        public DbSet<VentaDetalleBoletoAutobus> VentaDetalleBoletoAutobus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Comite");
            modelBuilder.HasDefaultSchema("Seguridad");
            modelBuilder.HasDefaultSchema("Sistema");
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
