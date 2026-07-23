using BeerC0d3.Core.Entities.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Comite
{
    public class UsuarioPeriodo
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int PeriodoId { get; set; }
        public Periodo Periodo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
