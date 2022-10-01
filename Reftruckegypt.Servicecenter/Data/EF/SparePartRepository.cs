using Reftruckegypt.Servicecenter.Data.Abstractions;
using System;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class SparePartRepository : Repository<Models.SparePart, Guid>, ISparePartRepository
    {
        public SparePartRepository(ReftruckDbContext context)
            :base(context)
        {

        }
    }
}
