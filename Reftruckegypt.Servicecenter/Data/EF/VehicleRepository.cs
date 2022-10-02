using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleRepository : Repository<Models.Vehicle, System.Guid>, IVehicleRepository
    {
        public VehicleRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
