namespace Reftruckegypt.Servicecenter.Models
{
    public class PurchaseRequestLine : EntityBase
    {
        public virtual SparePart SparePart { get; set; }
        public virtual Uom Uom { get; set; }
        public decimal RequestedQuantity { get; set; }
        public string Notes { get; set; }

        public const int MaxNotesLength = 500;
    }
}
