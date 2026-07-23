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
    public class CooperacionRepository: GenericRepository<Cooperacion>,ICooperacionRepository
    {
        public CooperacionRepository(BeerCodeContext context) : base(context)
        {

        }

      
    }
}
