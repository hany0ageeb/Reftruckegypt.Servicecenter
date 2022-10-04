using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels
{
    public class ExternalRepairBillVieModel
    {
        public ExternalRepairBillVieModel()
        {

        }
        public ExternalRepairBillVieModel(ExternalRepairBill externalRepairBill)
        {
            Id = externalRepairBill.Id;
            Number = externalRepairBill.Number;
            SupplierBillNumber = externalRepairBill.SupplierBillNumber;
            ExternalAutoRepairShopName = externalRepairBill.ExternalAutoRepairShop.Name;
            VehicleInternalCode = externalRepairBill.Vehicle.InternalCode;
            Repairs = externalRepairBill.Repairs;
            TotalAmount = externalRepairBill.TotalAmountInEGP;
            State = externalRepairBill.Period.State;
        }
        public Guid Id { get;  set; }
        public long Number { get;  set; }
        public DateTime BillDate { get;  set; }
        public string SupplierBillNumber { get;  set; }
        public string ExternalAutoRepairShopName { get;  set; }
        public string VehicleInternalCode { get;  set; }
        public string Repairs { get; set; }
        public decimal TotalAmount { get;  set; }
        public string State { get;  set; }

    }
}
