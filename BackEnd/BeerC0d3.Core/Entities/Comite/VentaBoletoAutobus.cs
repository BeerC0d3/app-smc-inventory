using BeerC0d3.Core.Entities.Sistema;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Comite
{
    public class VentaBoletoAutobus:BaseEntity
    {
        public int PeriodoId { get; set; }
        public Periodo Periodo { get; set; }
      
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public int EstatusId { get; set; }
        public CatalogoDetalle CatalogoDetalle { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
        public ICollection<VentaMontoBoletoAutobus> VentaMontoBoletoAutobus { get; set; }
        public ICollection<VentaDetalleBoletoAutobus> VentaDetalleBoletoAutobus { get; set; }

    }
}
