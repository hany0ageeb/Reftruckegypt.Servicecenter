using System;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class InternalMemoRepository : Repository<InternalMemo, Guid>, IInternalMemoRepository
    {
        public InternalMemoRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public IEnumerable<InternalMemo> Find(
            Guid? vehicleId = null, 
            DateTime? fromDate = null, 
            DateTime? toDate = null, 
            string header = "", 
            Func<IQueryable<InternalMemo>, IOrderedQueryable<InternalMemo>> orderBy = null)
        {
            IQueryable<InternalMemo> query = _context.Set<InternalMemo>().Include(nameof(InternalMemo.Vehicle));
            if(vehicleId!=null && vehicleId != Guid.Empty)
            {
                query = query.Where(x => x.PeriodId == vehicleId);
            }
            if (fromDate != null)
            {
                query = query.Where(x => x.MemoDate >= fromDate);
            }
            if(toDate != null)
            {
                query = query.Where(x => x.MemoDate <= toDate);
            }
            if (!string.IsNullOrEmpty(header))
            {
                query = query.Where(x => x.Header.Contains(header));
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
