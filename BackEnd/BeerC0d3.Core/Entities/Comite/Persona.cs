using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Comite
{
    public class Persona:BaseEntity
    {
        public int seccionId { get; set; }
        public Seccion Seccion { get; set; }
        public string Nombre { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }

        public ICollection<Cooperacion> Cooperaciones { get; set; }
        public ICollection<VentaBoletoAutobus> VentaBoletoAutobus { get; set; }
    }
}
