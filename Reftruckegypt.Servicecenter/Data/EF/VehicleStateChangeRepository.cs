using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleStateChangeRepository : Repository<Models.VehicleStateChange, System.Guid>, IVehicleStateChangeRepository
    {
        public VehicleStateChangeRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
