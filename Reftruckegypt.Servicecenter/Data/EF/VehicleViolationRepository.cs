using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleViolationRepository : Repository<Models.VehicleViolation, System.Guid>, IVehicleViolationRepository
    {
        public VehicleViolationRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        public IEnumerable<VehicleViolation> Find(Guid? vehicleId = null,
                                                  Guid? violationTypeId = null,
                                                  DateTime? fromDate = null,
                                                  DateTime? toDate = null,
                                                  Func<IQueryable<VehicleViolation>, IOrderedQueryable<VehicleViolation>> orderBy = null)
        {
            var query = ReftruckDbContext.VehicleViolations.AsQueryable();
            if(vehicleId != null && vehicleId != Guid.Empty)
            {
                query = query.Where(e => e.VehicleId == vehicleId);
            }
            if(violationTypeId != null && violationTypeId != Guid.Empty)
            {
                query = query.Where(e => e.ViolationTypeId == violationTypeId);
            }
            if (fromDate != null)
            {
                query = query.Where(e => e.ViolationDate >= fromDate);
            }
            if (toDate != null)
            {
                query = query.Where(e => e.ViolationDate <= toDate);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
