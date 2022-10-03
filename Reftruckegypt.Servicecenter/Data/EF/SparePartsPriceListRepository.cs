using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class SparePartsPriceListRepository : Repository<Models.SparePartsPriceList, System.Guid>, ISparePartsPriceListRepository
    {
        public SparePartsPriceListRepository(ReftruckDbContext context)
            : base(context)
        {

        }
    }
}
