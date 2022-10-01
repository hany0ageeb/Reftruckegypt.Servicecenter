using System;
using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class FuelCardRepository : Repository<Models.FuelCard, Guid>, IFuelCardRepository
    {
        public FuelCardRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
    }
}
