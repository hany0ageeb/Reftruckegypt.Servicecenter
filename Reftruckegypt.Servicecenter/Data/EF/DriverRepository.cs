using System;
using System.Collections.Generic;
using System.Linq;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class DriverRepository : Repository<Driver, Guid>, IDriverRepository
    {
        public DriverRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;

        public IEnumerable<Driver> Find(string driverName = "",
                                        string licenseNumber = "",
                                        DateTime? licenseEndDateFrom = null,
                                        DateTime? licenseEndDateTo = null,
                                        Func<IQueryable<Driver>, IOrderedQueryable<Driver>> orderBy = null)
        {
            IQueryable<Driver> query = ReftruckDbContext.Drivers.AsQueryable();
            if (!string.IsNullOrEmpty(driverName))
            {
                query = query.Where(e => e.Name.Contains(driverName));
            }
            if (!string.IsNullOrEmpty(licenseNumber))
            {
                query = query.Where(e => e.LicenseNumber.Contains(licenseNumber));
            }
            if (licenseEndDateFrom != null)
            {
                query = query.Where(e => e.LicenseEndDate >= licenseEndDateFrom);
            }
            if(licenseEndDateTo != null)
            {
                query = query.Where(e => e.LicenseEndDate <= licenseEndDateTo);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
