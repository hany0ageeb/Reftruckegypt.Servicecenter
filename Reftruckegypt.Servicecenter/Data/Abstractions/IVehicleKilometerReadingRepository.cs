using Reftruckegypt.Servicecenter.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IVehicleKilometerReadingRepository : IRepository<Models.VehicleKilometerReading, Guid>
    {
        IEnumerable<VehicleKilometerReading> Find(
            Guid? vehicleId = null, 
            DateTime? fromDate = null, 
            DateTime? toDate = null,
            Func<IQueryable<VehicleKilometerReading>,IOrderedQueryable<VehicleKilometerReading>> orderBy = null);
        decimal FindVehicleKilometerReadingAtDate(Guid vehicleId, DateTime readingDate);
    }
}
