using System;
using System.ComponentModel.DataAnnotations;

namespace Reftruckegypt.Servicecenter.Models
{
    public class SparePartsBillLine : EntityBase
    {
        public virtual SparePart SparePart { get; set; }
        public virtual Uom Uom { get; set; }
        [Range(double.Epsilon, double.MaxValue)]
        public decimal Quantity { get; set; }
        public Guid UomId { get; set; }
        public Guid SparePartId { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual SparePartsBill SparePartsBill { get; set; }
    }
}
