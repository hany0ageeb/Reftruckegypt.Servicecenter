using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels
{
    public class SparePartsBillLineViewModel
    {
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
        }
        public Guid Id { get; private set; }
        public Guid BillId { get; private set; }
        public long Number { get; private set; }
        public DateTime BillDate { get; set; }
        public decimal TotalAmount { get; private set; }
        public string VehicleInternalCode { get; private set; }
        public string State { get; private set; }
        public string SparePartCode { get; private set; }
        public string SparePartName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Quantity { get; private set; }
        public string UomCode { get; private set; }
        public string Repairs { get; private set; }
    }
}
