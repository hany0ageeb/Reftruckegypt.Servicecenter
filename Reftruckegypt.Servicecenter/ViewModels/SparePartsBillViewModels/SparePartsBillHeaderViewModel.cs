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
        }
        public Guid Id { get; private set; }
        public long Number { get; private set; }
        public DateTime BillDate { get; set; }
        public decimal TotalAmount { get; private set; }
        public string VehicleInternalCode { get; private set; }
        public string State { get; private set; }
        public string Repairs { get; private set; }
    }
}
