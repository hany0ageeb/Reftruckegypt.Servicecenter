using Reftruckegypt.Servicecenter.Models;
using System;
using Npoi.Mapper.Attributes;

namespace Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels
{
    public class ExternalRepairBillViewModel
    {
        public ExternalRepairBillViewModel()
        {

        }
        public ExternalRepairBillViewModel(ExternalRepairBill externalRepairBill)
        {
            Id = externalRepairBill.Id;
            Number = externalRepairBill.Number;
            SupplierBillNumber = externalRepairBill.SupplierBillNumber;
            ExternalAutoRepairShopName = externalRepairBill.ExternalAutoRepairShop?.Name;
            VehicleInternalCode = externalRepairBill.Vehicle?.InternalCode;
            Repairs = externalRepairBill.Repairs;
            TotalAmount = externalRepairBill.TotalAmountInEGP;
            State = externalRepairBill.Period?.State;
            PeriodId = externalRepairBill.PeriodId;
            ImageFilePath = externalRepairBill.BillImageFilePath;
            VehicleCategoryName = externalRepairBill.Vehicle?.VehicleCategory?.Name;
            VehicleModelName = externalRepairBill.Vehicle?.VehicleModel?.Name;
            DriverName = externalRepairBill.Vehicle?.Driver?.Name ?? "";
            MalfunctionReason = externalRepairBill.VehicleMalfunctionReason?.Name ?? "";
            KilometerReading = externalRepairBill.KilometerReading;
            BillDate = externalRepairBill.BillDate;
        }
        [Ignore]
        public Guid Id { get; set; }
        [Column("Number")]
        public long Number { get; set; }
        [Column("Bill Date")]
        public DateTime BillDate { get; set; }
        [Column("Supplier Bill Number")]
        public string SupplierBillNumber { get; set; }
        [Column("External Auto Repair Shop Name")]
        public string ExternalAutoRepairShopName { get; set; }
        [Column("Vehicle Category")]
        public string VehicleCategoryName { get; set; }
        [Column("Vehicle Model")]
        public string VehicleModelName { get; set; }
        [Column("Vehicle Internal Code")]
        public string VehicleInternalCode { get; set; }
        [Column("Kilometer Reading")]
        public decimal? KilometerReading { get; set; }
        [Column("Driver")]
        public string DriverName { get; set; }
        [Column("Malfunction Reason")]
        public string MalfunctionReason { get; set; }
        [Column("Repairs")]
        public string Repairs { get; set; }
        [Column("Total Amount")]
        public decimal TotalAmount { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("Invoice Image File Path")]
        public string ImageFilePath { get; set; }
        [Ignore]
        public Guid PeriodId { get; private set; }

    }
}
