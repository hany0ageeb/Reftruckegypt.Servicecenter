using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class FuelConsumptionRepository : Repository<FuelConsumption, Guid>, IFuelConsumptionRepository
    {
        public FuelConsumptionRepository(ReftruckDbContext context)
            :base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        public IEnumerable<IGrouping<FuelCard, FuelConsumption>> FindFuelConsumptionsGroupedByFuelcard(DateTime from, DateTime to)
        {
            return
                _context
                .Set<FuelConsumption>()
                .Where(x => x.ConsumptionDate >= from && x.ConsumptionDate <= to)
                .GroupBy(x => x.FuelCard);
        }
        
        public IEnumerable<FuelConsumption> Find(
            Guid? categoryId = null,
            Guid? modelId = null,
            Guid? vehicleId = null,
            Guid? fuelCardId = null,
            Guid? fuelTypeId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            Func<IQueryable<FuelConsumption>, IOrderedQueryable<FuelConsumption>> orderBy = null)
        {
            IQueryable<FuelConsumption> query = 
                _context
                .Set<FuelConsumption>()
                .Include(nameof(FuelConsumption.Vehicle))
                .Include(nameof(FuelConsumption.Period));
            if(categoryId!=null && categoryId != Guid.Empty)
            {
                query = query.Where(x => x.Vehicle.VehicleCategoryId == categoryId);
            }
            if(modelId!=null && modelId != Guid.Empty)
            {
                query = query.Where(x => x.Vehicle.VehicelModelId == modelId);
            }
            if(vehicleId!=null && vehicleId != Guid.Empty)
            {
                query = query.Where(x => x.VehicleId == vehicleId);
            }
            if(fuelCardId!=null && fuelCardId != Guid.Empty)
            {
                query = query.Where(x => x.FuelCardId == fuelCardId);
            }
            if(fuelTypeId!=null && fuelTypeId != Guid.Empty)
            {
                query = query.Where(x => x.FuelTypeId == fuelTypeId);
            }
            if (fromDate != null)
            {
                query = query.Where(x => x.ConsumptionDate >= fromDate);
            }
            if (toDate != null)
            {
                query = query.Where(x => x.ConsumptionDate <= toDate);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
