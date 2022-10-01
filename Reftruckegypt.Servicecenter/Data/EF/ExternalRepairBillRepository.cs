using System;
using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class ExternalRepairBillRepository : Repository<Models.ExternalRepairBill, Guid>, IExternalRepairBillRepository
    {
        public ExternalRepairBillRepository(ReftruckDbContext context)
            :base(context)
        {

        }
    }
}
