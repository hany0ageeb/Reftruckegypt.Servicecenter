using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class SparePartsBillRepository : Repository<Models.SparePartsBill, Guid>, ISparePartsBillRepository
    {
        public SparePartsBillRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        public IEnumerable<SparePartsBill> Find(Guid? vehicleId = null,
                                                DateTime? fromDate = null,
                                                DateTime? toDate = null,
                                                Func<IQueryable<SparePartsBill>, IQueryable<SparePartsBill>> orderBy = null)
        {
            IQueryable<SparePartsBill> query = 
                ReftruckDbContext
                .SparePartsBills
                .AsQueryable()
                .Include(x => x.Vehicle)
                .Include(x => x.Period);
            if(vehicleId != null && vehicleId != Guid.Empty)
            {
                query = query.Where(x => x.VehicleId == vehicleId);
            }
            if(fromDate != null)
            {
                query = query.Where(x => x.BillDate >= fromDate);
            }
            if(toDate != null)
            {
                query = query.Where(x => x.BillDate <= toDate);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
