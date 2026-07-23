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
    public class VentaDetalleBoletoAutobusRepository: GenericRepository<VentaDetalleBoletoAutobus>, IVentaDetalleBoletoAutobusRepository
    {
        public VentaDetalleBoletoAutobusRepository(BeerCodeContext context) : base(context)
        {

        }

        public async Task<VentaDetalleBoletoAutobus> GetByIdAndVentaBoletoId(int Id, int ventaBoletoId)
        {
            return await _context.VentaDetalleBoletoAutobus
                   .Where(item => item.Id == Id && item.VentaBoletoAutId == ventaBoletoId)
                   .FirstOrDefaultAsync();
        }
    }
}
