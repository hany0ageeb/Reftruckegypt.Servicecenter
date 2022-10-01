using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models
{
    public class SparePartsPriceList : EntityBase
    {
        public long Number { get; set; }
        public string Name { get; set; }
        public virtual Period Period { get; set; }
        public ICollection<SparePartPriceListLine> Lines { get; set; } = new HashSet<SparePartPriceListLine>();
    }
}
