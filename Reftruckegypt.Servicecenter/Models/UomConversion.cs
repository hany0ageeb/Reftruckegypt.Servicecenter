using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class UomConversion : EntityBase
    {
        public virtual SparePart SparePart { get; set; }
        public virtual Uom FromUom { get; set; }
        public Guid FromUomId { get; set; }
        public virtual Uom ToUom { get; set; }
        public Guid ToUomId { get; set; }
        public decimal Rate { get; set; }
        public Guid? SparePartId { get; set; }
    }
}
