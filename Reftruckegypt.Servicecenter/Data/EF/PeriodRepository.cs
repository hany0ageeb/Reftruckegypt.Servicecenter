using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
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
        public IEnumerable<Period> Find(
            string name = "", 
            DateTime? date = null, 
            Func<IQueryable<Period>, IOrderedQueryable<Period>> orderBy = null)
        {
            var query = ReftruckDbContext.Periods.Where(e => e.Name.Contains(name));
            if (date != null)
            {
                query = query.Where(e => date >= e.FromDate && date <= e.ToDate);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
