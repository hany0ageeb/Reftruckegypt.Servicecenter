using System;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class SparePartsBillLineRepository : Repository<SparePartsBillLine, Guid>, ISparePartsBillLineRepository
    {
        public SparePartsBillLineRepository(ReftruckDbContext context)
            : base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        public IEnumerable<SparePartsBillLine> Find(
            Guid? vehicleId = null,
            Guid? vehicleCategoryId = null,
            DateTime? fromDate = null, 
            DateTime? toDate = null, 
            Guid? sparePartId = null, 
            Func<IQueryable<SparePartsBillLine>, IOrderedQueryable<SparePartsBillLine>> orderBy = null)
        {
            IQueryable<SparePartsBillLine> query = 
                ReftruckDbContext
                .SparePartsBillLines
                .Include(x => x.SparePart)
                .Include(x => x.SparePartsBill)
                .Include(x => x.SparePartsBill.Vehicle)
                .Include(x => x.SparePartsBill.MalfunctionReason)
                .Include(x=>x.SparePartsBill.VehicleDriver)
                .AsQueryable();
            if(vehicleId != null && vehicleId != Guid.Empty)
            {
                query = query.Where(x => x.SparePartsBill.VehicleId == vehicleId);
            }
            if(vehicleCategoryId != null && vehicleCategoryId != Guid.Empty)
            {
                query = query.Where(x => x.SparePartsBill.Vehicle.VehicleCategoryId == vehicleCategoryId);
            }
            if(fromDate != null)
            {
                query = query.Where(x => x.SparePartsBill.BillDate >= fromDate);
            }
            if (toDate != null)
            {
                query = query.Where(x => x.SparePartsBill.BillDate <= toDate);
            }
            if(sparePartId != null && sparePartId != Guid.Empty)
            {
                query = query.Where(x => x.SparePartId == sparePartId);
            }
            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            return query.AsEnumerable();
        }
    }
}
