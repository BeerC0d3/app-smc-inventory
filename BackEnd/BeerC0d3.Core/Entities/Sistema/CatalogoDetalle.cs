


using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Entities.Seguridad;

namespace BeerC0d3.Core.Entities.Sistema
{
    public class CatalogoDetalle : BaseEntity
    {
        public int CatId { get; set; }
        public Catalogo Catalogo { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechAlta { get; set; }

        public ICollection<Periodo> Periodos { get; set; }
        public ICollection<Ingresos> Ingresos { get; set; }
        public ICollection<Egresos> Egresos { get; set; }
        public ICollection<VentaBoletoAutobus> VentaBoletoAutobus { get; set; }
    }
}
