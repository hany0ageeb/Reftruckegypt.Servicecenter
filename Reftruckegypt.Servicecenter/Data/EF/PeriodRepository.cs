using Reftruckegypt.Servicecenter.Data.Abstractions;
using System;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class PeriodRepository : Repository<Models.Period, Guid>, IPeriodRepository
    {
        public PeriodRepository(ReftruckDbContext context)
            :base(context)
        {

        }
    }
}
