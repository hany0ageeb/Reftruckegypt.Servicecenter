using System;
using System.Linq;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class PurchaseRequestLineRepository : Repository<PurchaseRequestLine, Guid>, IPurchaseRequestLineRepository
    {
        public PurchaseRequestLineRepository(ReftruckDbContext context)
            : base(context)
        {

        }

        public IEnumerable<PurchaseRequestLine> Find(
            Guid? vehicleId = null, 
            Guid? sparePartId = null, 
            DateTime? fromDate = null, 
            DateTime? toDate = null,
            Func<IQueryable<PurchaseRequestLine>, IOrderedQueryable<PurchaseRequestLine>> orderBy = null)
        {
            IQueryable<PurchaseRequestLine> query = 
                _context.Set<PurchaseRequestLine>()
                .Include(nameof(PurchaseRequestLine.PurchaseRequest))
                .Include(nameof(PurchaseRequestLine.SparePart))
                .Include(nameof(PurchaseRequestLine.Uom))
                .Include(nameof(PurchaseRequestLine.ReceiptLines));
            if(vehicleId!=null && vehicleId != Guid.Empty)
            {
                query = query.Where(x => x.PurchaseRequest.VehicleId == vehicleId);
            }
            if(sparePartId!=null && sparePartId != Guid.Empty)
            {
                query = query.Where(x => x.SparePartId == sparePartId);
            }
            if (fromDate != null)
            {
                query = query.Where(x => x.PurchaseRequest.RequestDate >= fromDate);
            }
            if (toDate != null)
            {
                query = query.Where(x => x.PurchaseRequest.RequestDate <= toDate);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
