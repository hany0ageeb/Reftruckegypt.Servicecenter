using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class SparePartPriceListLine : EntityBase
    {
        public virtual SparePart SparePart { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Uom Uom { get; set; }
        public Guid UomId { get; set; }
        public Guid SparePartId { get; set; }
        public decimal? UomConversionRate { get; set; } = null;
        public virtual SparePartsPriceList SparePartsPriceList { get; set;}
    }
}
