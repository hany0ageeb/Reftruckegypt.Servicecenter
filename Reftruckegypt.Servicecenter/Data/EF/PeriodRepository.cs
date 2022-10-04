using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class PeriodRepository : Repository<Period, Guid>, IPeriodRepository
    {
        public PeriodRepository(ReftruckDbContext context)
            :base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        public Period FindOpenPeriod(DateTime date)
        {
            return ReftruckDbContext.Periods.Where(e => e.State == PeriodStates.OpenState && e.FromDate <= date && e.ToDate >= date).FirstOrDefault();
        }

    }
}
