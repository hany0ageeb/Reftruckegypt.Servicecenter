using System;
using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class ExternalAutoRepairShopRepository : Repository<Models.ExternalAutoRepairShop, Guid>, IExternalAutoRepairShopRepository
    {
        public ExternalAutoRepairShopRepository(ReftruckDbContext context)
            :base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
    }
}
