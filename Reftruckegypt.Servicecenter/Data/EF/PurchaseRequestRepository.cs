using System;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class PurchaseRequestRepository : Repository<PurchaseRequest, Guid>, IPurchaseRequestRepository
    {
        public PurchaseRequestRepository(ReftruckDbContext context)
            : base(context)
        {

        }

        public IEnumerable<PurchaseRequest> Find(
            Guid? vehicleId = null, 
            DateTime? fromDate = null, 
            DateTime? toDate = null, 
            Func<IQueryable<PurchaseRequest>, IOrderedQueryable<PurchaseRequest>> orderBy = null)
        {
            IQueryable<PurchaseRequest> query = _context.Set<PurchaseRequest>().Include(nameof(PurchaseRequest.Period));
            if(vehicleId != null && vehicleId != Guid.Empty)
            {
                query = query.Where(x => x.VehicleId == vehicleId);
            }
            if (fromDate != null)
            {
                query = query.Where(x => x.RequestDate >= fromDate);
            }
            if (toDate != null)
            {
                query = query.Where(x => x.RequestDate <= toDate);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
