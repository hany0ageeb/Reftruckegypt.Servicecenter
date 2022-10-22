using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class ReceiptLine : EntityBase
    {
        public virtual PurchaseRequestLine PurchaseRequestLine { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public virtual Period Period { get; set; }
        public virtual SparePart SparePart { get; set; }
        public virtual Uom Uom { get; set; }
        public decimal ReceivedQuantity { get; set; }
        public string Notes { get; set; }
        public Guid PurchaseRequestLineId { get; set; }
        public Guid SparePartId { get; set; }
        public Guid UomId { get; set; }
        public Guid PeriodId { get; set; }

        public const int MaxNotesLength = 500;
    }
}
