using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Comite
{
    public class BoletoAutobus:BaseEntity
    {
      
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }

        public ICollection<VentaDetalleBoletoAutobus> VentaDetalleBoletos { get; set; }
    }
}
