using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleModelRepository : Repository<Models.VehicleModel, System.Guid>, IVehicleModelRepository
    {
        public VehicleModelRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
