using Reftruckegypt.Servicecenter.Data.Abstractions;
using System;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class LocationRepository : Repository<Models.Location, Guid>, ILocationRepository
    {
        public LocationRepository(ReftruckDbContext context)
            :base(context)
        {

        }
    }
}
