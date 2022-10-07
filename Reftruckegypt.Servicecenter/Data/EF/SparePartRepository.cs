using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class SparePartRepository : Repository<Models.SparePart, Guid>, ISparePartRepository
    {
        public SparePartRepository(ReftruckDbContext context)
            :base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        
    }
}
