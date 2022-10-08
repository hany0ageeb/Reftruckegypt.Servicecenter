using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IFuelCardRepository : IRepository<FuelCard, Guid>
    {
        IEnumerable<FuelCard> Find(
            string name = "", 
            string number = "", 
            string registration = "",
            Guid? vehicleId = null,
            Func<IQueryable<FuelCard>, IOrderedQueryable<FuelCard>> orderBy = null);
    }
}
