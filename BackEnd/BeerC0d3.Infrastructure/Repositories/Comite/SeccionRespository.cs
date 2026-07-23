using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Interfaces.Comite;
using BeerC0d3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Repositories.Comite
{
    public class SeccionRepository : GenericRepository<Seccion>, ISeccionRepository
    {
        public SeccionRepository(BeerCodeContext context) : base(context)
        {

        }

        public async Task<ICollection<Seccion>> GetActiveAllByUserAsync(int userId)
        {
            return await _context.Secciones
                .Include(u=> u.UsuarioSecciones)
                     .Where(item => item.Activo
                     && item.UsuarioSecciones.Any(us=> us.UsuarioId == userId)).ToListAsync();
        }

        public async Task<Seccion> GetSeccionByUserAsync(int userId,int seccionId)
        {
            return await _context.Secciones
                .Include(su=> su.UsuarioSecciones)
                     .Where(item => item.Activo
                     && item.Id == seccionId
                     && item.UsuarioSecciones.Any(us => us.UsuarioId == userId && us.SeccionId == seccionId)).FirstOrDefaultAsync();
        }
    }
}
