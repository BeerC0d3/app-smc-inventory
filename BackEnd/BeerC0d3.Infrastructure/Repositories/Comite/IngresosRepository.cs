using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Interfaces.Comite;
using BeerC0d3.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Repositories.Comite
{
    public class IngresosRepository:GenericRepository<Ingresos>,IIngresosRepository
    {
        public IngresosRepository(BeerCodeContext context) : base(context)
        {

        }
    }
}
