using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.FuelCardViewModels
{
    public class FuelCardViewModel
    {
        public FuelCardViewModel(FuelCard fuelCard)
        {
            Id = fuelCard.Id;
            Number = fuelCard.Number;
            Name = fuelCard.Name;
            Registration = fuelCard.Registration;
            VehicleInternalCode = fuelCard.Vehicle.InternalCode;
            VehicleChassisNumber = fuelCard.Vehicle.ChassisNumber;
        }
        [Ignore]
        public Guid Id { get; private set; }
        [Column("Number")]
        public string Number { get; private set; }
        [Column("Name")]
        public string Name { get; private set; }
        [Column("Registration")]
        public string Registration { get; private set; }
        [Column("Vehicle Internal Code")]
        public string VehicleInternalCode { get; private set; }
        [Column("Vehicle Chassis Number")]
        public string VehicleChassisNumber { get; private set; }
    }
}
