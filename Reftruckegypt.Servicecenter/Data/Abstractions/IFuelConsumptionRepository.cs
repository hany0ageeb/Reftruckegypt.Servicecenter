using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IFuelConsumptionRepository : IRepository<FuelConsumption, Guid>
    {
        IEnumerable<FuelConsumption> Find(
            Guid? categoryId = null, 
            Guid? modelId = null,
            Guid? vehicleId = null,
            Guid? fuelCardId = null,
            Guid? fuelTypeId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            Func<IQueryable<FuelConsumption>, IOrderedQueryable<FuelConsumption>> orderBy = null);
    }
}
