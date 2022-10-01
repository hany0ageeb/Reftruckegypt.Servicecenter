using System;
using System.ComponentModel.DataAnnotations;

namespace Reftruckegypt.Servicecenter.Models
{
    public class VehicleViolation : EntityBase
    {
        public Vehicle Vehicle { get; set; }
        public Guid VehicleId { get; set; }
        [Range(1, int.MaxValue)]
        public int Count { get; set; } = 1;
        public Period Period { get; set; }
        public Guid PeriodId { get; set; }
        public ViolationType ViolationType { get; set; }
        public Guid ViolationTypeId { get; set; }

        public string Notes { get; set; }
    }
}
