using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.InternalMemoViewModels
{
    public class InternalMemoDTO
    {
        public InternalMemoDTO()
        {

        }
        public InternalMemoDTO(InternalMemo internalMemo)
        {
            Id = internalMemo.Id;
            Number = internalMemo.Number;
            Header = internalMemo.Header;
            Content = internalMemo.Content;
            MemoDate = internalMemo.MemoDate;
            VehicleInternalCode = internalMemo.Vehicle?.InternalCode;
            State = internalMemo.Period?.State;
        }
        [Ignore]
        public Guid Id { get; private set; }
        [Column("Number")]
        public long Number { get; set; }
        [Column("Memo Subject")]
        public string Header { get; set; }
        [Column("Memo Content")]
        public string Content { get; set; }
        [Column("Memo Date")]
        public DateTime MemoDate { get; set; }
        [Column("Vehicle Internal Code")]
        public string VehicleInternalCode { get; set; }
        [Column("State")]
        public string State { get; set; }
    }
}
