using BeerC0d3.Core.Entities.Seguridad;
using BeerC0d3.Core.Entities.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Comite
{
    public class Periodo : BaseEntity
    {
        //public int Id { get; set; }
        public string Nombre { get; set; }
        public int EstatusId { get; set; }
        public CatalogoDetalle CatalogoDetalle { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public ICollection<UsuarioPeriodo> UsuarioPeriodos { get; set; }
        public ICollection<Ingresos> Ingresos { get; set; }
        public ICollection<Egresos> Egresos { get; set; }

        public ICollection<Cooperacion> Cooperaciones { get; set; }
        public ICollection<VentaBoletoAutobus> VentaBoletoAutobus { get; set; }

    }
}
