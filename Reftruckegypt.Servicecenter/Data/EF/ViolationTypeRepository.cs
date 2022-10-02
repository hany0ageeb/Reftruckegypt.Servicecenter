using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class ViolationTypeRepository : Repository<Models.ViolationType, System.Guid>, IViolationTypeRepository
    {
        public ViolationTypeRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
