using System;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class SparePartPriceListLineRepository : Repository<SparePartPriceListLine, Guid>, ISparePartPriceListLineRepository
    {
        public SparePartPriceListLineRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;

        public IEnumerable<SparePartPriceListLine> Find(
            DateTime? fromDate = null,
            DateTime? todate = null,
            Guid? sparePartId = null,
            Func<IQueryable<SparePartPriceListLine>, IOrderedQueryable<SparePartPriceListLine>> orderBy = null)
        {
            IQueryable<SparePartPriceListLine> query = ReftruckDbContext.SparePartPriceListLines.AsQueryable();
            if (fromDate != null)
            {
                query = query.Where(x => x.SparePartsPriceList.Period.FromDate >= fromDate);
            }
            if (todate != null)
            {
                query = query.Where(x => x.SparePartsPriceList.Period.ToDate <= todate);
            }
            if(sparePartId != null && sparePartId != Guid.Empty)
            {
                query = query.Where(x => x.SparePartId == sparePartId);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
