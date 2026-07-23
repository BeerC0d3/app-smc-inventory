using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Comite
{
    public class VentaMontoBoletoAutobus : BaseEntity
    {
        public int VentaBoletoAutId { get; set; }
        public VentaBoletoAutobus VentaBoletoAutobus { get; set; }
        public decimal Monto { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
