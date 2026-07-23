using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Comite
{
    public class Cooperacion:BaseEntity
    {
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public int PeriodoId { get; set; }
        public Periodo Periodo { get; set; }
        public decimal Monto { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
