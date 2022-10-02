using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleViolationRepository : Repository<Models.VehicleViolation, System.Guid>, IVehicleViolationRepository
    {
        public VehicleViolationRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
