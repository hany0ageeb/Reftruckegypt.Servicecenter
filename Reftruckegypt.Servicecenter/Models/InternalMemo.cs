using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class InternalMemo : EntityBase
    {
        public long Number { get; set; }
        public DateTime MemoDate { get; set; } = DateTime.Now;
        public virtual Period Period { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public Guid VehicleId { get; set; }
        public Guid PeriodId { get; set; }
        public const int MaxHeaderLength = 250;
        public const int MaxContentLength = 1500;
    }
}
