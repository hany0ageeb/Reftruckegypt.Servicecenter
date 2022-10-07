using System;
using Reftruckegypt.Servicecenter.Models;
using System.Linq;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface ISparePartRepository : IRepository<Models.SparePart, Guid>
    {
        
    }
}
