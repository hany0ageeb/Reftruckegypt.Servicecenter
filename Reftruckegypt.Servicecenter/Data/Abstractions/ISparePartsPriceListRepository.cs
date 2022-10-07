using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface ISparePartsPriceListRepository : IRepository<SparePartsPriceList, Guid>
    {
        IEnumerable<SparePartsPriceList> Find(
            DateTime? fromDate = null,
            DateTime? toDate = null,
            Func<IQueryable<SparePartsPriceList>, IOrderedQueryable<SparePartsPriceList>> orderBy = null);
    }
}
