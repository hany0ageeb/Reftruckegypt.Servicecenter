using System;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class SparePartsBillLineRepository : Repository<SparePartsBillLine, Guid>, ISparePartsBillLineRepository
    {
        public SparePartsBillLineRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
