using System;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleLicenseRepository : Repository<VehicleLicense, Guid>, IVehicleLicenseRepository
    {
        public VehicleLicenseRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
