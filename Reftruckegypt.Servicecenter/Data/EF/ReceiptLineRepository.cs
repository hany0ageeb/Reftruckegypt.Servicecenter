using System;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class ReceiptLineRepository : Repository<ReceiptLine, Guid>, IReceiptLineRepository
    {
        public ReceiptLineRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public IEnumerable<ReceiptLine> Find(Guid? purchaseRequestId = null,
                                             Guid? vehicleId = null,
                                             DateTime? fromDate = null,
                                             DateTime? toDate = null,
                                             Func<IQueryable<ReceiptLine>, IOrderedQueryable<ReceiptLine>> orderBy = null)
        {
            IQueryable<ReceiptLine> query = _context.Set<ReceiptLine>();
            if(purchaseRequestId != null && purchaseRequestId != Guid.Empty)
            {
                query = query.Where(x=>x.PurchaseRequestLine.PurchaseRequestId == purchaseRequestId);
            }
            if(vehicleId!=null && vehicleId != Guid.Empty)
            {
                query = query.Where(x => x.PurchaseRequestLine.PurchaseRequest.VehicleId == vehicleId);
            }
            if (fromDate != null)
            {
                query = query.Where(x => x.ReceiptDate >= fromDate);
            }
            if (toDate != null)
            {
                query = query.Where(x => x.ReceiptDate <= toDate);
            }
            if (orderBy != null)
                return query.AsEnumerable();
            return query.AsEnumerable();
        }
    } 
}
