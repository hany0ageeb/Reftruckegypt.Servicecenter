using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IExternalRepairBillRepository : IRepository<ExternalRepairBill, Guid>
    {
        IEnumerable<TResult> Find<TResult>(
            Expression<Func<ExternalRepairBill, TResult>> selector,
            long? fromNumber = null, 
            long? toNumber = null,
            string supplierBillNumber="",
            DateTime? fromDate = null,
            DateTime? toDate = null,
            decimal? fromAmount = null,
            decimal? toAmount = null,
            Guid? externalShopId = null,
            Guid? vehicleId = null,
            Func<IQueryable<ExternalRepairBill>, IOrderedQueryable<ExternalRepairBill>> orderBy = null)
            where TResult : new();
    }
}
