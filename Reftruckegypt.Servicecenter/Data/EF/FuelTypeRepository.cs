using System;
using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class FuelTypeRepository : Repository<Models.FuelType, Guid>, IFuelTypeRepository
    {
        public FuelTypeRepository(ReftruckDbContext context)
            :base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
    }
}
