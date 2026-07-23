using BeerC0d3.Core.Entities.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Comite
{
    public class Ingresos:BaseEntity
    {
        public int PeriodoId { get; set; }
        public Periodo Periodo { get; set; }
        public int ConcentoId { get; set; }
        public CatalogoDetalle CatalogoDetalle { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
