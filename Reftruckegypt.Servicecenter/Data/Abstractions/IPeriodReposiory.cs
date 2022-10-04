using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IPeriodRepository : IRepository<Models.Period, Guid>
    {
        Period FindOpenPeriod(DateTime date);
    }
}
