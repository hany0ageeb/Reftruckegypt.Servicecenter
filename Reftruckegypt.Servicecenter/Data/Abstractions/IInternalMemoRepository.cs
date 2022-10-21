using System;
using System.Linq;
using System.Collections.Generic;
using Reftruckegypt.Servicecenter.Models;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IInternalMemoRepository : IRepository<InternalMemo, Guid>
    {
        IEnumerable<InternalMemo> Find(
            Guid? vehicleId = null, 
            DateTime? fromDate = null, 
            DateTime? toDate = null,
            string header = "",
            Func<IQueryable<InternalMemo>, IOrderedQueryable<InternalMemo>> orderBy = null);
    }
}
