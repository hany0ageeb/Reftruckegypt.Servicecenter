using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IUomConversionRepository : IRepository<UomConversion, Guid>
    {
        IEnumerable<UomConversion> Find(
            Guid? sparePartId = null,
            Guid? fromUomId = null,
            Guid? toUomId = null,
            Func<IQueryable<UomConversion>, IOrderedQueryable<UomConversion>> orderBy = null);
    }
}
