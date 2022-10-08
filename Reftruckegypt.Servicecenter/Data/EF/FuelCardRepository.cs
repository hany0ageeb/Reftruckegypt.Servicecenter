using System;
using System.Collections.Generic;
using System.Linq;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class FuelCardRepository : Repository<FuelCard, Guid>, IFuelCardRepository
    {
        public FuelCardRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        public IEnumerable<FuelCard> Find(
            string name = "", 
            string number = "", 
            string registration = "", 
            Guid? vehicleId = null, 
            Func<IQueryable<FuelCard>, IOrderedQueryable<FuelCard>> orderBy = null)
        {
            IQueryable<FuelCard> query = ReftruckDbContext.FuelCards;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(number))
            {
                query = query.Where(x => x.Number.Contains(number));
            }
            if (!string.IsNullOrEmpty(registration))
            {
                query = query.Where(x => x.Registration.Contains(registration));
            }
            if(vehicleId != null && vehicleId != Guid.Empty)
            {
                query = query.Where(x => x.Vehicle.Id == vehicleId);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
