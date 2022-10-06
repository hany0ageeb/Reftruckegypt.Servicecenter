using System;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class UomConversionRepository : Repository<UomConversion, Guid>, IUomConversionRepository
    {
        public UomConversionRepository(ReftruckDbContext context)
            : base(context)
        {
        }
    }
}
