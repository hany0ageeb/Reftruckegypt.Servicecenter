using Reftruckegypt.Servicecenter.Data.Abstractions;
using System;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleCategoryRepository : Repository<Models.VehicleCategory, Guid>, IVehicleCategoryRepository
    {
        public VehicleCategoryRepository(ReftruckDbContext context)
            :base(context)
        {

        }
    }
}
