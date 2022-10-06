using System;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class UomConversionRepository : Repository<UomConversion, Guid>, IUomConversionRepository
    {
        public UomConversionRepository(ReftruckDbContext context)
            : base(context)
        {
        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext; 
        public IEnumerable<UomConversion> Find(Guid? sparePartId = null,
                                               Guid? fromUomId = null,
                                               Guid? toUomId = null,
                                               Func<IQueryable<UomConversion>, IOrderedQueryable<UomConversion>> orderBy = null)
        {
            IQueryable<UomConversion> query = ReftruckDbContext.UomConversions.AsQueryable();
            if(sparePartId != null && sparePartId != Guid.Empty)
            {
                query = query.Where(e => e.SparePartId == sparePartId);
            }
            if(fromUomId != null && fromUomId != Guid.Empty)
            {
                query = query.Where(e => e.FromUomId == fromUomId);
            }
            if(toUomId != null && toUomId != Guid.Empty)
            {
                query = query.Where(e => e.ToUomId == toUomId);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
