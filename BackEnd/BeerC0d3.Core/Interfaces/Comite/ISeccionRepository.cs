using BeerC0d3.Core.Entities.Comite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Interfaces.Comite
{
    public interface ISeccionRepository:IGenericRepository<Seccion>
    {
        Task<ICollection<Seccion>> GetActiveAllByUserAsync(int userId);
        Task<Seccion> GetSeccionByUserAsync(int userId,int seccionId);
    }
}
