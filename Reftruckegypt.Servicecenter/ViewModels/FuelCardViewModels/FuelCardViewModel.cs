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
        public Guid Id { get; private set; }
        public string Number { get; private set; }
        public string Name { get; private set; }
        public string Registration { get; private set; }
        public string VehicleInternalCode { get; private set; }
        public string VehicleChassisNumber { get; private set; }
    }
}
