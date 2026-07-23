using BeerC0d3.Core.Entities.Comite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Interfaces.Comite
{
    public interface IPeriodoRepository : IGenericRepository<Periodo>
    {
        Task<ICollection<Periodo>> GetActiveAllAsync();
        Task<Periodo> GetByEstatusAsync(int estatusId);
        Task<Periodo> GetPeriodoUsuariosByPId(int pId);
        Task<Periodo> GetByPeoIdAsync(int peoId);
    }
}
