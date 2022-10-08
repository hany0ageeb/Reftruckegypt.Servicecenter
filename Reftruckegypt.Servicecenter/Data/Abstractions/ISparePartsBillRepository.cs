using System;
using System.Collections.Generic;
using System.Linq;
using Reftruckegypt.Servicecenter.Models;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface ISparePartsBillRepository : IRepository<SparePartsBill, Guid>
    {
        IEnumerable<SparePartsBill> Find(
            Guid? vehicleId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            Func<IQueryable<SparePartsBill>, IQueryable<SparePartsBill>> orderBy = null);
    }
}
