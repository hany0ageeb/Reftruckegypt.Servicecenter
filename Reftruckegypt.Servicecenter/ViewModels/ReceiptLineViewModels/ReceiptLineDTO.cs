using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.ReceiptLineViewModels
{
    public class ReceiptLineDTO
    {
        public ReceiptLineDTO() { }
        public ReceiptLineDTO(ReceiptLine line)
        {
            Id = line.Id;
            SparePartCode = line.SparePart?.Code;
            SparePartName = line.SparePart?.Name;
            UomCode = line.Uom?.Code;
            ReceivedQuantity = line.ReceivedQuantity;
            ReceiptDate = line.ReceiptDate;
            PeriodState = line.Period.State;
        }
        [Ignore]
        public Guid Id { get; private set; }
        public string SparePartCode { get; set; }
        public string SparePartName { get; set; }
        public string UomCode { get; set; }
        public decimal ReceivedQuantity { get; set; }
        public string PeriodState { get; set; }
        public DateTime ReceiptDate { get; set; }
    }
}
