using System;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class SparePartPriceListLineRepository : Repository<SparePartPriceListLine, Guid>, ISparePartPriceListLineRepository
    {
        public SparePartPriceListLineRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
