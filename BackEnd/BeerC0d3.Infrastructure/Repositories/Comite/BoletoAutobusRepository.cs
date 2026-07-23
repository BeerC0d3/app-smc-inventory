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
    public class BoletoAutobusRepository:GenericRepository<BoletoAutobus>,IBoletoAutobusRepository
    {
        public BoletoAutobusRepository(BeerCodeContext context) : base(context)
        {

        }

        public async Task<IEnumerable<BoletoAutobus>> GetAllActive()
        {
            return await _context.BoletoAutobus.Where(item => item.Activo)
                .ToListAsync();
        }
    }
}
