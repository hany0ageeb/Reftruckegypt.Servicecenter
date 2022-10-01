using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reftruckegypt.Servicecenter.Models
{
    public class ExternalRepairBill : EntityBase
    {
        public long Number { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ExternalAutoRepairShop ExternalAutoRepairShop { get; set; }
        public Guid VehicleId { get; set; }
        public Guid ExternalAutoRepairShopId { get; set; }
        public DateTime BillDate { get; set; } = DateTime.Now;
        public string Repairs { get; set; }
        [Range(0,double.MaxValue)]
        public decimal TotalAmountInEGP { get; set; } = 0;
        public virtual Period Period { get; set; }
        public Guid PeriodId { get; set; }
    }
    public class SparePartsPriceList : EntityBase
    {
        public string Name { get; set; }
        public virtual Period Period { get; set; }
        public Guid PeriodId { get; set; }
        public ICollection<SparePartPriceListLine> Lines { get; set; } = new HashSet<SparePartPriceListLine>();
    }
    public class SparePartPriceListLine : EntityBase
    {
        public virtual SparePart SparePart { get; set; }
        public decimal unitPrice { get; set; }
        public virtual Uom Uom { get; set; }
        public Guid UomId { get; set; }
        public Guid SparePartId { get; set; }
    }
    public class SparePartsBill : EntityBase
    {
        public DateTime BillDate { get; set; } = DateTime.Now;
        public virtual Vehicle Vehicle { get; set; }
        public string Repairs { get; set; }

    }
    public class SparePartsBillLine : EntityBase
    {
        public virtual SparePart SparePart { get; set; }
        public virtual Uom Uom { get; set; }
        public decimal Quantity { get; set; }
    }
}
