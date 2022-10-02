using System;
using System.ComponentModel.DataAnnotations;

namespace Reftruckegypt.Servicecenter.Models
{
    public class ExternalRepairBill : EntityBase
    {
        public long Number { get; set; }
        public string SupplierBillNumber { get; set; }
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
        public string BillImageFilePath { get; set; }

        public const int MaxSupplierBillNumberLength = 50;
        public const int MaxRepairsLength = 1500;
        public const int MaxBillImageFilePathLength = 1000;
    }
}
