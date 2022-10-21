using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class InternalMemo : EntityBase
    {
        public long Number { get; set; }
        public DateTime MemoDate { get; set; } = DateTime.Now;
        public string Header { get; set; }
        public string Content { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public Guid VehicleId { get; set; }
    }
}
