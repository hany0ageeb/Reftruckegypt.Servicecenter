using System;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models
{
    public class PurchaseRequestLine : EntityBase
    {
        public virtual SparePart SparePart { get; set; }
        public virtual Uom Uom { get; set; }
        public decimal RequestedQuantity { get; set; }
        public string Notes { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; }
        public Guid PurchaseRequestId { get; set; }
        public Guid SparePartId { get; set; }
        public Guid UomId { get; set; }
        public virtual ICollection<ReceiptLine> ReceiptLines { get; set; } = new HashSet<ReceiptLine>();

        public const int MaxNotesLength = 500;
    }
}
