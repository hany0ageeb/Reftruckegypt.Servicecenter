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
        [Column("Code")]
        public string SparePartCode { get; set; }
        [Column("Name")]
        public string SparePartName { get; set; }
        [Column("Uom")]
        public string UomCode { get; set; }
        [Column("Received Quantity")]
        public decimal ReceivedQuantity { get; set; }
        public string PeriodState { get; set; }
        [Column("Receipt Date")]
        public DateTime ReceiptDate { get; set; }
    }
}
