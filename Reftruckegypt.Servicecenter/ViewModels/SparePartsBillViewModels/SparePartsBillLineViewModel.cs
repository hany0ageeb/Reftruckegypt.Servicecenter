using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels
{
    public class SparePartsBillLineViewModel
    {
        public SparePartsBillLineViewModel() { }
        public SparePartsBillLineViewModel(SparePartsBillLine line)
        {
            Id = line.Id;
            BillId = line.SparePartsBill.Id;
            Number = line.SparePartsBill.Number;
            BillDate = line.SparePartsBill.BillDate;
            TotalAmount = line.TotalAmount;
            VehicleInternalCode = line.SparePartsBill.Vehicle.InternalCode;
            State = line.SparePartsBill.Period.State;
            UnitPrice = line.UnitPrice;
            Quantity = line.Quantity;
            UomCode = line.Uom.Code;
            Repairs = line.SparePartsBill.Repairs;
            SparePartCode = line.SparePart.Code;
            SparePartName = line.SparePart.Name;
            DriverName = line.SparePartsBill.VehicleDriver?.Name ?? "";
            KilometerReading = line.SparePartsBill.KilometerReading;
        }
        [Ignore]
        public Guid Id { get; private set; }
        [Ignore]
        public Guid BillId { get; private set; }
        [Column("Number")]
        public long Number { get; private set; }
        [Column("Bill Date")]
        public DateTime BillDate { get; set; }
        [Column("Total Amount")]
        public decimal TotalAmount { get; private set; }
        [Column("Vehicle Internal Code")]
        public string VehicleInternalCode { get; private set; }
        [Column("Kilometer Reading")]
        public decimal? KilometerReading { get; set; }
        [Column("Driver")]
        public string DriverName { get; set; }
        [Column("State")]
        public string State { get; private set; }
        [Column("Spare Part Code")]
        public string SparePartCode { get; private set; }
        [Column("Spare Part Name")]
        public string SparePartName { get; private set; }
        [Column("Unit Price")]
        public decimal? UnitPrice { get; private set; }
        [Column("Quantity")]
        public decimal Quantity { get; private set; }
        [Column("Uom Code")]
        public string UomCode { get; private set; }
        [Column("Repairs")]
        public string Repairs { get; private set; }
    }
}
