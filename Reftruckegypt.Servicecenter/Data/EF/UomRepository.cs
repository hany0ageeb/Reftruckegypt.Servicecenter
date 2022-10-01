using Reftruckegypt.Servicecenter.Data.Abstractions;
using System;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class UomRepository : Repository<Models.Uom, Guid>, IUomRepository
    {
        public UomRepository(ReftruckDbContext context)
            :base(context)
        {

        }
    }
}
