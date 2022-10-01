using System;
using System.ComponentModel.DataAnnotations;

namespace Reftruckegypt.Servicecenter.Models
{
    public class VehicleKilometerReading : EntityBase
    {
        public virtual Vehicle Vehicle { get; set; }
        public DateTime ReadingDate { get; set; } = DateTime.Now;
        public Period Period { get; set; }
        [Range(0.0, double.MaxValue)]
        public decimal Reading { get; set; }
        public string Notes { get; set; }
        public Guid VehicleId { get; set; }
        public Guid PeriodId { get; set; }
    }
}
