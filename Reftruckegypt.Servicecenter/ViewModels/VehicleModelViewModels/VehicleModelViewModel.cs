using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleModelViewModels
{
    public class VehicleModelViewModel
    {
        public VehicleModelViewModel()
        {
            Id = Guid.Empty;
            Name = "";
            Description = "";
            DefaultFuelTypeName = "";
        }
        public VehicleModelViewModel(VehicleModel vehicleModel)
        {
            Name = vehicleModel.Name;
            Description = vehicleModel.Description;
            DefaultFuelTypeName = vehicleModel.DefaultFuelType?.Name;
            Id = vehicleModel.Id;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string DefaultFuelTypeName { get; private set; }
    }
}
