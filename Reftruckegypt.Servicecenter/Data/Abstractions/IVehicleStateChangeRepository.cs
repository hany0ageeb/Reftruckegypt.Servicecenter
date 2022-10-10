using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IVehicleStateChangeRepository : IRepository<VehicleStateChange, Guid>
    {
        IEnumerable<VehicleStateChange> Find(
            Guid? vehicleId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            Func<IQueryable<VehicleStateChange>, IOrderedQueryable<VehicleStateChange>> orderBy = null);
    }
}
