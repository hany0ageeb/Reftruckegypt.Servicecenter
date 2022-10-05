using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class VehicleStateChange : EntityBase
    {
        public virtual Vehicle Vehicle { get; set; }
        public string State { get; set; } = VehicleStates.Broken;
        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime? ToDate { get; set; } = null;
        public string Notes { get; set; }
        public Guid VehicleId { get; set; }

        public const int MaxNotesLength = 500;
        public const int MaxStateLength = 50;
    }
}
