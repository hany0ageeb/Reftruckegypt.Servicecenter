using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IReceiptLineRepository : IRepository<ReceiptLine, Guid>
    {
        IEnumerable<ReceiptLine> Find(
            Guid? purchaseRequestId = null,
            Guid? vehicleId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            Func<IQueryable<ReceiptLine>, IOrderedQueryable<ReceiptLine>> orderBy = null);
    }
}
