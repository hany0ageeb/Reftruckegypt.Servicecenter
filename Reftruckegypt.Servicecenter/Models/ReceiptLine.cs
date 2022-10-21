using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class ReceiptLine : EntityBase
    {
        public virtual PurchaseRequest PurchaseRequest { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public virtual Period Period { get; set; }
        public virtual SparePart SparePart { get; set; }
        public virtual Uom Uom { get; set; }
        public decimal ReceivedQuantity { get; set; }
        public string Notes { get; set; }
        public Guid PurchaseRequestId { get; set; }
    }
}
