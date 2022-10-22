using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IPurchaseRequestLineRepository : IRepository<PurchaseRequestLine, Guid>
    {
        IEnumerable<PurchaseRequestLine> Find(
            Guid? vehicleId = null,
            Guid? sparePartId = null,
            DateTime? fromDate = null, 
            DateTime? toDate = null,
            Func<IQueryable<PurchaseRequestLine>, IOrderedQueryable<PurchaseRequestLine>> orderBy = null);
    }
}
