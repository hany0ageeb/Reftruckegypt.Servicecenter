using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class UserCommandRepository : Repository<UserCommand, Guid>, IUserCommandRepository
    {
        public UserCommandRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
