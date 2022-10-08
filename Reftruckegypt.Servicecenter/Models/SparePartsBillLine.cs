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
        public decimal TotalAmount => Quantity * UnitPrice;
        public decimal? UomConversionRate { get; set; } = null;
        public virtual SparePartsBill SparePartsBill { get; set; }
        public string Notes { get; set; }
        public const int MaxNotesLength = 500;
    }
}
