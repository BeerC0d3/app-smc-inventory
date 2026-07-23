using BeerC0d3.Core.Entities.Sistema;
using BeerC0d3.Core.Interfaces.Sistema;
using BeerC0d3.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Repositories.Sistema
{
    public class CatalogoRepository : GenericRepository<Catalogo>, ICatalogoRepository
    {
        public CatalogoRepository(BeerCodeContext context) : base(context)
        {

        }
    }
}
