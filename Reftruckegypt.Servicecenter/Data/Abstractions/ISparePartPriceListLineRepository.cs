using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface ISparePartPriceListLineRepository : IRepository<SparePartPriceListLine, Guid>
    {
        IEnumerable<SparePartPriceListLine> Find(
            DateTime? fromDate = null, 
            DateTime? todate = null,
            Guid? sparePartId = null,
            Func<IQueryable<SparePartPriceListLine>,IOrderedQueryable<SparePartPriceListLine>> orderBy = null);
    }
}
