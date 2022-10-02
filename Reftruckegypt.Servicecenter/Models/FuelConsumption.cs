using System;
using System.ComponentModel.DataAnnotations;

namespace Reftruckegypt.Servicecenter.Models
{
    public class FuelConsumption : EntityBase
    {
        public virtual Vehicle Vehicle { get; set; }
        public virtual FuelCard FuelCard { get; set; }
        public Period Period { get; set; }
        public DateTime ConsumptionDate { get; set; } = DateTime.Now;
        [Range(double.Epsilon,double.MaxValue)]
        public decimal TotalConsumedQuanityInLiteres { get; set; }
        [Range(0, double.MaxValue)]
        public decimal TotalAmountInEGP { get; set; }
        public Guid FuelCardId { get; set; }
        public Guid PeriodId { get; set; }
        public Guid VehicleId { get; set; }
        public string Notes { get; set; }

        public const int MaxFuelConsumptionNotesLength = 500;
    }
}
