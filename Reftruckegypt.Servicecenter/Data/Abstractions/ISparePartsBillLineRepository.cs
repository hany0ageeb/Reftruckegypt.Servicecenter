using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface ISparePartsBillLineRepository : IRepository<SparePartsBillLine, Guid>
    {
        IEnumerable<SparePartsBillLine> Find(
            Guid? vehicleId = null,
            Guid? vehicleCategoryId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            Guid? sparePartId = null,
            Func<IQueryable<SparePartsBillLine>, IOrderedQueryable<SparePartsBillLine>> orderBy = null);
    }
}
