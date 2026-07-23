using BeerC0d3.Core.Entities.Comite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Seguridad
{
    public class Usuario : BaseEntity
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FotoUrl { get; set; }
        public bool EmailConfirmado { get; set; }
        public bool Activo { get; set; }

        public DateTime FechaRegistro { get; set; }
        public string CodigoActivacion { get; set; }
        public DateTime? FechaActivacion { get; set; }

        public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
        public ICollection<UsuariosRoles> UsuariosRoles { get; set; }

        public ICollection<Seccion> Secciones { get; set; } = new HashSet<Seccion>();
        public ICollection<UsuarioSeccion> UsuarioSecciones { get; set; }

        public ICollection<Periodo> Periodos { get; set; } = new HashSet<Periodo>();
        public ICollection<UsuarioPeriodo> UsuarioPeriodos { get; set; }
    }
}
