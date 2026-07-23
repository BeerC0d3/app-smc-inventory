using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Comite
{
    public class VentaDetalleBoletoAutobus:BaseEntity
    {
        public int VentaBoletoAutId { get; set; }
        public VentaBoletoAutobus VentaBoletoAutobus { get; set; }
        public int BoletoAutId { get; set; }
        public BoletoAutobus BoletoAutobus { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
