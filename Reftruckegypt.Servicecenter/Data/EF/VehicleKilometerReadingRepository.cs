using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleKilometerReadingRepository : Repository<Models.VehicleKilometerReading, System.Guid>, IVehicleKilometerReadingRepository
    {
        public VehicleKilometerReadingRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
