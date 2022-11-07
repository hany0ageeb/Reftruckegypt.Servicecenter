using System;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class MalfunctionReasonRepository : Repository<MalfunctionReason, Guid>, IMalfunctionReasonRepository
    {
        public MalfunctionReasonRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
