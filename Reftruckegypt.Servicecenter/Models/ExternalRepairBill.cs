using System;
using System.ComponentModel.DataAnnotations;

namespace Reftruckegypt.Servicecenter.Models
{
    public class ExternalRepairBill : EntityBase
    {
        public long Number { get; set; }
        public string SupplierBillNumber { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public decimal? KilometerReading { get; set; }
        public virtual ExternalAutoRepairShop ExternalAutoRepairShop { get; set; }
        public virtual Driver VehicleDriver { get; set; }
        public virtual MalfunctionReason VehicleMalfunctionReason { get; set; }
        public Guid VehicleId { get; set; }
        public Guid ExternalAutoRepairShopId { get; set; }
        public DateTime BillDate { get; set; } = DateTime.Now;
        public string Repairs { get; set; }
        [Range(0,double.MaxValue)]
        public decimal TotalAmountInEGP { get; set; } = 0;
        public virtual Period Period { get; set; }
        public Guid PeriodId { get; set; }
        public Guid? VehicleDriverId { get; set; }
        public Guid? VehicleMalfunctionReasonId { get; set; }
        public string BillImageFilePath { get; set; }

        public const int MaxSupplierBillNumberLength = 50;
        public const int MaxRepairsLength = 1500;
        public const int MaxBillImageFilePathLength = 1000;
    }
    public class MalfunctionReason : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; } = true;
        public MalfunctionReason Self => this;
        public static readonly MalfunctionReason empty = new MalfunctionReason() { Id = Guid.Empty, Name = "" };
        public const int MaxNameLength = 100;
        public const int MaxDescriptionLength = 500;
    }
}
