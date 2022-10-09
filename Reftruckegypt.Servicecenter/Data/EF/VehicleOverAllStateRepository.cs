using System;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleOverAllStateRepository : Repository<VehicleOverAllState, Guid>, IVehicleOverAllStateRepository
    {
        public VehicleOverAllStateRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
