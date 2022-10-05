using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleKilometerReadingRepository : Repository<Models.VehicleKilometerReading, System.Guid>, IVehicleKilometerReadingRepository
    {
        public VehicleKilometerReadingRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        public IEnumerable<VehicleKilometerReading> Find(
            Guid? vehicleId = null, 
            DateTime? fromDate = null, 
            DateTime? toDate = null, 
            Func<IQueryable<VehicleKilometerReading>, IOrderedQueryable<VehicleKilometerReading>> orderBy = null)
        {
            IQueryable<VehicleKilometerReading> query = ReftruckDbContext.VehicleKilometerReadings.AsQueryable();
            if(vehicleId != null && vehicleId != Guid.Empty)
            {
                query = query.Where(e => e.VehicleId == vehicleId);
            }
            if (fromDate != null)
            {
                query = query.Where(e => e.ReadingDate >= fromDate);
            }
            if (toDate != null)
            {
                query = query.Where(e => e.ReadingDate <= toDate);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
