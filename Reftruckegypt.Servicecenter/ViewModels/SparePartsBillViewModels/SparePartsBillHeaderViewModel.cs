using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels
{
    public class SparePartsBillHeaderViewModel
    {
        public SparePartsBillHeaderViewModel(SparePartsBill bill)
        {
            Id = bill.Id;
            Number = bill.Number;
            BillDate = bill.BillDate;
            State = bill.Period.State;
            VehicleInternalCode = bill.Vehicle.InternalCode;
            TotalAmount = bill.Lines.Sum(e => e.TotalAmount);
            Repairs = bill.Repairs;
            DriverName = bill.VehicleDriver?.Name ?? "";
            KilometerReading = bill.KilometerReading;
            MalfunctionReason = bill.MalfunctionReason?.Name ?? "";
            VehicleCategoryName = bill.Vehicle?.VehicleCategory?.Name ?? "";
            VehicleModelName = bill.Vehicle?.VehicleModel?.Name ?? "";
        }
        [Ignore]
        public Guid Id { get; private set; }
        [Column("Number")]
        public long Number { get; private set; }
        [Column("Bill Date")]
        public DateTime BillDate { get; set; }
        [Column("Total Amount")]
        public decimal TotalAmount { get; private set; }
        [Column("Category")]
        public string VehicleCategoryName { get; set; }
        [Column("Model")]
        public string VehicleModelName { get; set; }
        [Column("Vehicle Internal Code")]
        public string VehicleInternalCode { get; private set; }
        [Column("Kilometer Reading")]
        public decimal? KilometerReading { get; set; }
        [Column("Malfunction Reason")]
        public string MalfunctionReason { get; set; }
        [Column("Driver")]
        public string DriverName { get; set; }
        [Column("State")]
        public string State { get; private set; }
        [Column("Repairs")]
        public string Repairs { get; private set; }
    }
}
