using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IPurchaseRequestRepository : IRepository<PurchaseRequest, Guid>
    {
        IEnumerable<PurchaseRequest> Find(
            Guid? vehicleId = null,
            DateTime? fromDate = null, 
            DateTime? toDate = null,
            Func<IQueryable<PurchaseRequest>, IOrderedQueryable<PurchaseRequest>> orderBy = null);
    }
}
