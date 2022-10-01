using System;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models
{
    public class SparePartsBill : EntityBase
    {
        public long Number { get; set; }
        public DateTime BillDate { get; set; } = DateTime.Now;
        public virtual Vehicle Vehicle { get; set; }
        public virtual Period Period { get; set; }
        public string Repairs { get; set; }
        public virtual ICollection<SparePartsBillLine> Lines { get; set; } = new HashSet<SparePartsBillLine>();
        public Guid VehicleId { get; set; }
        public Guid PeriodId { get; set; }

    }
}
