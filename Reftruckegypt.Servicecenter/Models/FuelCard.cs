using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reftruckegypt.Servicecenter.Models
{
    public class FuelCard : EntityBase
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Registration { get; set; }
        public virtual Vehicle Vehicle { get; set; }
     
        public const int MaxFuelCardNumberLength = 20;
        public const int MaxFuelCardNameLength = 250;
        public const int MaxFuelCardRegistrationLength = 20;
    }
}
