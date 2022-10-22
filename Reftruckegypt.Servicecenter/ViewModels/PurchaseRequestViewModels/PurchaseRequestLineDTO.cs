using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.PurchaseRequestViewModels
{
    public class PurchaseRequestLineDTO
    {
        public PurchaseRequestLineDTO()
        {

        }
        public PurchaseRequestLineDTO(PurchaseRequestLine line)
        {
            PurchaseRequestLineId = line.Id;
            PucrhaseRequestId = line.PurchaseRequest.Id;
            Number = line.PurchaseRequest.Number;
            RequestDate = line.PurchaseRequest.RequestDate;
            SparePartCode = line.SparePart.Code;
            SparePartName = line.SparePart.Name;
            UomCode = line.Uom.Code;
            RequestedQuantity = line.RequestedQuantity;
            ReceivedQuantity = line.ReceiptLines.Sum(x => x.ReceivedQuantity);
            PeriodState = line.PurchaseRequest.Period.State;
            RequestState = line.PurchaseRequest.State;
        }
        [Ignore]
        public Guid PurchaseRequestLineId { get; set; }
        [Ignore]
        public Guid PucrhaseRequestId { get; set; }
        [Column("Number")]
        public long Number { get; set; }
        [Column("Request Date")]
        public DateTime RequestDate { get; set; }
        [Column("Part Code")]
        public string SparePartCode { get; set; }
        [Column("Part Name")]
        public string SparePartName { get; set; }
        [Column("Uom")]
        public string UomCode { get; set; }
        [Column("Requested Quantity")]
        public decimal RequestedQuantity { get; set; }
        [Column("Received Quantity")]
        public decimal ReceivedQuantity { get; set; }
        [Ignore]
        public string PeriodState { get; set; }
        [Ignore]
        public string RequestState { get; set; }
    }
}
