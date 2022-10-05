using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IPeriodRepository : IRepository<Models.Period, Guid>
    {
        Period FindOpenPeriod(DateTime date);
        IEnumerable<Period> Find(
            string name = "", 
            DateTime? date = null,
            Func<IQueryable<Period>, IOrderedQueryable<Period>> orderBy = null);
    }
}
