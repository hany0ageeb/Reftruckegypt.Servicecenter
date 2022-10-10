using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleStateChangeRepository : Repository<VehicleStateChange, Guid>, IVehicleStateChangeRepository
    {
        public VehicleStateChangeRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        public IEnumerable<VehicleStateChange> Find(
            Guid? vehicleId = null, 
            DateTime? fromDate = null, 
            DateTime? toDate = null, 
            Func<IQueryable<VehicleStateChange>, IOrderedQueryable<VehicleStateChange>> orderBy = null)
        {
            IQueryable<VehicleStateChange> query = _context
                .Set<VehicleStateChange>()
                .Include(nameof(VehicleStateChange.Vehicle));
            if(vehicleId!=null && vehicleId != Guid.Empty)
            {
                query = query.Where(x => x.VehicleId == vehicleId);
            }
            if (fromDate != null)
            {
                query = query.Where(x => x.FromDate >= fromDate);
            }
            if(toDate != null)
            {
                query = query.Where(x => x.ToDate <= toDate || x.ToDate == null);
            }
            if (orderBy is null)
                return query.AsEnumerable();
            return orderBy(query).AsEnumerable();
        }
    }
}
