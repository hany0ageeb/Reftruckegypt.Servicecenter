using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class SparePartsPriceListRepository : Repository<SparePartsPriceList, Guid>, ISparePartsPriceListRepository
    {
        public SparePartsPriceListRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        public IEnumerable<SparePartsPriceList> Find(
            DateTime? fromDate = null,
            DateTime? toDate = null,
            Func<IQueryable<SparePartsPriceList>, IOrderedQueryable<SparePartsPriceList>> orderBy = null)
        {
            IQueryable<SparePartsPriceList> query = ReftruckDbContext.SparePartsPriceLists.AsQueryable();
            if (fromDate != null)
            {
                query = query.Where(e => e.Period.FromDate >= fromDate);
            }
            if (toDate != null)
            {
                query = query.Where(e => e.Period.ToDate <= toDate);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
