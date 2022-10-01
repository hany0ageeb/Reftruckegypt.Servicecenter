using Reftruckegypt.Servicecenter.Data.Abstractions;
using System;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class SparePartsBillRepository : Repository<Models.SparePartsBill, Guid>, ISparePartsBillRepository
    {
        public SparePartsBillRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
