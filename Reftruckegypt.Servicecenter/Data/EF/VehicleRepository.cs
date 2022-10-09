using System;
using System.Linq;
using System.Collections.Generic;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System.Data.Entity;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class VehicleRepository : Repository<Vehicle, Guid>, IVehicleRepository
    {
        public VehicleRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        public IEnumerable<Vehicle> Find(
            string internalCode = "",
            string plateNumber = "",
            string motorNumber = "",
            string workingState= "",
            string chassis = "",
            Guid? categoryId = null,
            Guid? modelId = null,
            Guid? fuelTypeId = null,
            Guid? fuelCardId = null,
            Guid? workingLocationId = null,
            Guid? maintenanceLocationId = null,
            Func<IQueryable<Vehicle>,IOrderedQueryable<Vehicle>> orderBy = null)
        {
            IQueryable<Vehicle> query = ReftruckDbContext.Vehicels.AsQueryable().Include(x=>x.VehicelLicenses);
            if (!string.IsNullOrEmpty(internalCode))
            {
                query = query.Where(x => x.InternalCode.Contains(internalCode));
            }
            if (!string.IsNullOrEmpty(chassis))
            {
                query = query.Where(x => x.ChassisNumber.Contains(chassis));
            }
            if (!string.IsNullOrEmpty(plateNumber))
            {
                query = query.Where(x => x.VehicelLicenses.Select(z => z.PlateNumber).Contains(plateNumber));
            }
            if (!string.IsNullOrEmpty(motorNumber))
            {
                query = query.Where(x => x.VehicelLicenses.Select(z => z.MotorNumber).Contains(motorNumber));
            }
            if (!string.IsNullOrEmpty(workingState))
            {
                query = query.Where(x => x.WorkingState == workingState);
            }
            if(categoryId!=null && categoryId != Guid.Empty)
            {
                query = query.Where(x => x.VehicleCategoryId == categoryId);
            }
            if(modelId!=null && modelId != Guid.Empty)
            {
                query = query.Where(x => x.VehicelModelId == modelId);
            }
            if(fuelTypeId != null && fuelTypeId != Guid.Empty)
            {
                query = query.Where(x => x.FuelTypeId == fuelTypeId);
            }
            if(fuelCardId==null || fuelCardId != Guid.Empty)
            {
                query = query.Where(x => x.FuelCard.Id == fuelCardId || x.FuelCard == null);
            }
            if (workingLocationId != null && workingLocationId != Guid.Empty)
            {
                query = query.Where(x => x.WorkLocationId == workingLocationId);
            }
            if(maintenanceLocationId != null && maintenanceLocationId != Guid.Empty)
            {
                query = query.Where(x => x.MaintenanceLocationId == maintenanceLocationId);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();

            return query.AsEnumerable();
        }
    }
}
