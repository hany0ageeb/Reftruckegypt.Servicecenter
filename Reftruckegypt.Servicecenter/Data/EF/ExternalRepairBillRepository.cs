using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class ExternalRepairBillRepository : Repository<ExternalRepairBill, Guid>, IExternalRepairBillRepository
    {
        public ExternalRepairBillRepository(ReftruckDbContext context)
            :base(context)
        {

        }
        public ReftruckDbContext ReftruckDbContext => _context as ReftruckDbContext;
        public IEnumerable<TResult> Find<TResult>(Expression<Func<ExternalRepairBill, TResult>> selector,
                                                  long? fromNumber = null,
                                                  long? toNumber = null,
                                                  string supplierBillNumber = "",
                                                  DateTime? fromDate = null,
                                                  DateTime? toDate = null,
                                                  decimal? fromAmount = null,
                                                  decimal? toAmount = null,
                                                  Guid? externalShopId = null,
                                                  Guid? vehicleCategoryId = null,
                                                  Guid? vehicleId = null,
                                                  Func<IQueryable<ExternalRepairBill>, IOrderedQueryable<ExternalRepairBill>> orderBy = null) where TResult : new()
        {
            IQueryable<ExternalRepairBill> query = ReftruckDbContext.ExternalRepairBills;
            if (fromNumber != null)
            {
                query = query.Where(b=>b.Number>=fromNumber);
            }
            if (toNumber != null)
            {
                query = query.Where(b => b.Number <= toNumber);
            }
            if (!string.IsNullOrEmpty(supplierBillNumber))
            {
                query = query.Where(b => b.SupplierBillNumber.Contains(supplierBillNumber));
            }
            if (fromDate != null)
            {
                query = query.Where(b => b.BillDate >= fromDate);
            }
            if (toDate != null)
            {
                query = query.Where(b => b.BillDate < toDate);
            }
            if(vehicleCategoryId!=null && vehicleCategoryId != Guid.Empty)
            {
                query = query.Where(x => x.Vehicle.VehicleCategoryId == vehicleCategoryId);
            }
            if (vehicleId != null && vehicleId != Guid.Empty)
            {
                query = query.Where(b => b.VehicleId == vehicleId);
            }
            if(externalShopId!=null && externalShopId != Guid.Empty)
            {
                query = query.Where(b => b.ExternalAutoRepairShopId == externalShopId);
            }
            if(fromAmount != null)
            {
                query = query.Where(b => b.TotalAmountInEGP >= fromAmount);
            }
            if(toAmount != null)
            {
                query = query.Where(b => b.TotalAmountInEGP <= toAmount);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            var finalResult = query.Select(selector);
            return finalResult.AsEnumerable();
        }

        public IEnumerable<ExternalRepairBill> Find(long? fromNumber = null,
                                                    long? toNumber = null,
                                                    string supplierBillNumber = "",
                                                    DateTime? fromDate = null,
                                                    DateTime? toDate = null,
                                                    decimal? fromAmount = null,
                                                    decimal? toAmount = null,
                                                    Guid? externalShopId = null,
                                                    Guid? vehicleCategoryId = null,
                                                    Guid? vehicleId = null,
                                                    Func<IQueryable<ExternalRepairBill>, IOrderedQueryable<ExternalRepairBill>> orderBy = null)
        {
            IQueryable<ExternalRepairBill> query = ReftruckDbContext.ExternalRepairBills;
            if (fromNumber != null)
            {
                query = query.Where(b => b.Number >= fromNumber);
            }
            if (toNumber != null)
            {
                query = query.Where(b => b.Number <= toNumber);
            }
            if (!string.IsNullOrEmpty(supplierBillNumber))
            {
                query = query.Where(b => b.SupplierBillNumber.Contains(supplierBillNumber));
            }
            if (fromDate != null)
            {
                query = query.Where(b => b.BillDate >= fromDate);
            }
            if (toDate != null)
            {
                query = query.Where(b => b.BillDate < toDate);
            }
            if (vehicleCategoryId != null && vehicleCategoryId != Guid.Empty)
            {
                query = query.Where(x => x.Vehicle.VehicleCategoryId == vehicleCategoryId);
            }
            if (vehicleId != null && vehicleId != Guid.Empty)
            {
                query = query.Where(b => b.VehicleId == vehicleId);
            }
            if (externalShopId != null && externalShopId != Guid.Empty)
            {
                query = query.Where(b => b.ExternalAutoRepairShopId == externalShopId);
            }
            if (fromAmount != null)
            {
                query = query.Where(b => b.TotalAmountInEGP >= fromAmount);
            }
            if (toAmount != null)
            {
                query = query.Where(b => b.TotalAmountInEGP <= toAmount);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return query.AsEnumerable();
        }
    }
}
