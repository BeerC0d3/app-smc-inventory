using BeerC0d3.Core.Entities.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Interfaces.Sistema
{
    public interface ICatalogoDetalleRepository : IGenericRepository<CatalogoDetalle>
    {
        Task<CatalogoDetalle> GetCatDetalleByClaveAsync(string catDetalleClave);
        Task<ICollection<CatalogoDetalle>> GetCatDetalleByCatIDAsync(int catID);
        Task<List<CatalogoDetalle>> GetCatDetalleByCatClaveAsync(string catClave);
        Task<CatalogoDetalle> GetCatDetalleByCatalogoAsync(string claveCatalogo);
    }
}
