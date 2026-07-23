using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Interfaces.Comite;
using BeerC0d3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Repositories.Comite
{
    public class PeriodoRepository: GenericRepository<Periodo>,IPeriodoRepository
    {
        public PeriodoRepository(BeerCodeContext context) : base(context)
        {

        }

        public async Task<ICollection<Periodo>> GetActiveAllAsync()
        {
            return await _context.Periodos
                 .Where(item => item.Activo).ToListAsync();
        }

        public async Task<Periodo> GetByEstatusAsync(int estatusId)
        {
            return await _context.Periodos
                .Include(u => u.CatalogoDetalle)
                .Where(item => item.EstatusId == estatusId).FirstOrDefaultAsync();
        }

        public async Task<Periodo> GetByPeoIdAsync(int peoId)
        {
            return await _context.Periodos
            .Include(u => u.Usuarios)
            .Include(u=> u.UsuarioPeriodos)
                .Where(item => item.Id == peoId).FirstOrDefaultAsync();
        }

        public async Task<Periodo> GetPeriodoUsuariosByPId(int poId)
        {
            return await _context.Periodos
               .Include(u => u.Usuarios)
               .Where(item => item.Id == poId).FirstOrDefaultAsync();
        }
    }
}
