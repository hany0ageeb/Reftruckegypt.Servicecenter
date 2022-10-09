using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IVehicleRepository : IRepository<Vehicle, Guid>
    {
        IEnumerable<Vehicle> Find(
            string internalCode = "",
            string plateNumber = "",
            string motorNumber = "",
            string workingState = "",
            string chassis = "",
            Guid? categoryId = null,
            Guid? modelId = null,
            Guid? fuelTypeId = null,
            Guid? fuelCardId = null,
            Guid? workingLocationId = null,
            Guid? maintenanceLocationId = null,
            Func<IQueryable<Vehicle>, IOrderedQueryable<Vehicle>> orderBy = null);
    }
}
