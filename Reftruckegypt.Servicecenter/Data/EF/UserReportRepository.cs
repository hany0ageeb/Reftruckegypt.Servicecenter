using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class UserReportRepository : Repository<UserReport, Guid>, IUserReportRepository
    {
        public UserReportRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
