using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.PurchaseRequestViewModels
{
    public class PurchaseRequestDTO
    {
        public PurchaseRequestDTO()
        {

        }
        public PurchaseRequestDTO(PurchaseRequest purchaseRequest)
        {
            PurchaseRequestId = purchaseRequest.Id;
            Number = purchaseRequest.Number;
            RequestDate = purchaseRequest.RequestDate;
            Description = purchaseRequest.Description;
            RequestState = purchaseRequest.State;
            PeriodState = purchaseRequest.Period.State;
            VehicleInternalCode = purchaseRequest.Vehicle?.InternalCode ?? "";
        }
        [Ignore]
        public Guid PurchaseRequestId { get; set; }
        [Column("Number")]
        public long Number { get; set; }
        [Column("Vehicle")]
        public string VehicleInternalCode { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Request Date")]
        public DateTime RequestDate { get; set; }
        [Column("Request State")]
        public string RequestState { get; set; }
        [Ignore]
        public string PeriodState { get; set; }
    }
}
