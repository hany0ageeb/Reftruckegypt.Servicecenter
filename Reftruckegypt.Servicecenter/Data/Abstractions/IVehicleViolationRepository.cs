using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IVehicleViolationRepository : IRepository<Models.VehicleViolation, Guid>
    {
        IEnumerable<VehicleViolation> Find(
            Guid? vehicleId = null, 
            Guid? violationTypeId = null, 
            DateTime? fromDate = null, 
            DateTime? toDate = null,
            Func<IQueryable<VehicleViolation>, IOrderedQueryable<VehicleViolation>> orderBy = null);
    }
}
