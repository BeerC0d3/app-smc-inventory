using BeerC0d3.Core.Entities.Seguridad;
using BeerC0d3.Core.Entities.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Comite
{
    public class Seccion:BaseEntity
    {
        //public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public ICollection<UsuarioSeccion> UsuarioSecciones { get; set; }

        public ICollection<Persona> Personas { get; set; }
    }
}
