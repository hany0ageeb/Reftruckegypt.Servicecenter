using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Models
{
    public class SparePartsPriceList : EntityBase
    {
        public long Number { get; set; }
        public string Name { get; set; }
        public virtual Period Period { get; set; }
        public virtual IList<SparePartPriceListLine> Lines { get; set; } = new List<SparePartPriceListLine>();

        public const int MaxPriceListNameLength = 250;
        public decimal? FindUnitPrice(SparePart sparePart, Uom uom = null)
        {
            var line = Lines.Where(l => l.SparePartId == sparePart.Id).FirstOrDefault();
            if (line == null)
                return 0M;
            if(uom is null)
            {
                return line.UnitPrice * (1.0M / line.UomConversionRate);
            }
            else
            {
                if (uom.Id == line.UomId)
                    return line.UnitPrice;
                if(uom.Id == line.SparePart.PrimaryUomId)
                    return line.UnitPrice * (1.0M/line.UomConversionRate);
                decimal? rate = sparePart.PrimaryUom.Convert(uom, 1, sparePart);
                return line.UnitPrice * line.UomConversionRate * rate;
            }

        }
    }
}
