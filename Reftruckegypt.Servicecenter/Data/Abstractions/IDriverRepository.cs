using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IDriverRepository : IRepository<Driver, Guid>
    {
        IEnumerable<Driver> Find(
            string driverName = "", 
            string licenseNumber = "",
            DateTime? licenseEndDateFrom = null,
            DateTime? licenseEndDateTo = null,
            Func<IQueryable<Driver>, IOrderedQueryable<Driver>> orderBy = null);
    }
}
