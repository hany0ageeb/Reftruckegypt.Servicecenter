using System;
using System.Linq;
using Reftruckegypt.Servicecenter.Models;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleViewModels
{
    public class VehicleViewModel
    {
        public VehicleViewModel(Vehicle vehicle)
        {
            Id = vehicle.Id;
            InternalCode = vehicle.InternalCode;
            ChassisNumber = vehicle.ChassisNumber;
            DriverName = vehicle.Driver?.Name;
            FuelCardNumber = vehicle.FuelCard?.Number;
            FuelTypeName = vehicle.FuelType.Name;
            MaintenanceLocationName = vehicle.MaintenanceLocation?.Name;
            WorkingLocationName = vehicle.WorkLocation?.Name;
            ModelYear = vehicle.ModelYear.ToString();
            OvallStateName = vehicle.OverAllState?.Name;
            ModelName = vehicle.VehicleModel.Name;
            WorkingState = vehicle.WorkingState;
            if(vehicle.VehicelLicenses.Count > 0)
            {
                var orderLicenses = vehicle.VehicelLicenses.OrderByDescending(l => l.EndDate).ToList();
                PlateNumber = orderLicenses[0].PlateNumber;
            }
            else
            {
                PlateNumber = "";
            }
        }
        public Guid Id { get; private set; }
        public string InternalCode { get; private set; }
        public string ChassisNumber { get; private set; }
        public string DriverName { get; private set; }
        public string FuelCardNumber { get; private set; }
        public string FuelTypeName { get; private set; }
        public string MaintenanceLocationName { get; private set; }
        public string WorkingLocationName { get; private set; }
        public string ModelYear { get; private set; }
        public string OvallStateName { get; private set; }
        public string ModelName { get; private set; }
        public string WorkingState { get; private set; }
        public string PlateNumber { get; private set; }
    }
}
