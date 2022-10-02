using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class FuelCard : EntityBase
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Registration { get; set; }
        public Vehicle Vehicel { get; set; }
        public Guid VehicelId { get; set; }

        public const int MaxFuelCardNumberLength = 20;
        public const int MaxFuelCardNameLength = 250;
        public const int MaxFuelCardRegistrationLength = 20;
    }
}
