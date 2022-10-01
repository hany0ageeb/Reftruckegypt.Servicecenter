using Reftruckegypt.Servicecenter.Data.Abstractions;
using System;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class FuelConsumptionRepository : Repository<Models.FuelConsumption, Guid>, IFuelConsumptionRepository
    {
        public FuelConsumptionRepository(ReftruckDbContext context)
            :base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
    }
}
