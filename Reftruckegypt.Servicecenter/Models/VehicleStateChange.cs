using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class VehicleStateChange : EntityBase
    {
        public virtual Vehicle Vehicle { get; set; }
        public virtual Period Period { get; set; }
        public string State { get; set; } = VehicleStates.Broken;
        public DateTime StateChangeDate { get; set; } = DateTime.Now;
        public string Notes { get; set; }
        public Guid VehicleId { get; set; }
        public Guid PeriodId { get; set; }
    }
}
