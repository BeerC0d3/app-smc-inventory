using BeerC0d3.Core.Entities.Sistema;
using BeerC0d3.Core.Interfaces.Sistema;
using BeerC0d3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Repositories.Sistema
{
    public class CatalogoDetalleRepository : GenericRepository<CatalogoDetalle>, ICatalogoDetalleRepository
    {
        public CatalogoDetalleRepository(BeerCodeContext context) : base(context)
        {

        }

        public Task<CatalogoDetalle> GetCatDetalleByCatalogoAsync(string claveCatalogo)
        {

            throw new NotImplementedException();
        }

        public async Task<List<CatalogoDetalle>> GetCatDetalleByCatClaveAsync(string catClave)
        {

            var result = await _context.CatalogoDetalles
                            .Include(u => u.Catalogo)
                            .Where(item => item.CatId == item.Catalogo.Id && item.Catalogo.Clave == catClave).ToListAsync();

            return result;

        }

        public Task<ICollection<CatalogoDetalle>> GetCatDetalleByCatIDAsync(int catID)
        {
            throw new NotImplementedException();
        }

        public async Task<CatalogoDetalle> GetCatDetalleByClaveAsync(string catDetalleClave)
        {
            return await _context.CatalogoDetalles
                .Where(item => item.Clave == catDetalleClave)
                .FirstOrDefaultAsync();

        }
    }
}
