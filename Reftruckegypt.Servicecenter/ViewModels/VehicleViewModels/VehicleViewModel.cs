using System;
using System.Linq;
using Npoi.Mapper.Attributes;
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
        [Ignore]
        public Guid Id { get; private set; }
        [Column("Internal Code")]
        public string InternalCode { get; private set; }
        [Column("Chassis Number")]
        public string ChassisNumber { get; private set; }
        [Column("Driver Name")]
        public string DriverName { get; private set; }
        [Column("Fuel Card Number")]
        public string FuelCardNumber { get; private set; }
        [Column("Fuel Type Name")]
        public string FuelTypeName { get; private set; }
        [Column("Maintenance Location")]
        public string MaintenanceLocationName { get; private set; }
        [Column("Working Location")]
        public string WorkingLocationName { get; private set; }
        [Column("Model Year")]
        public string ModelYear { get; private set; }
        [Column("Over all State")]
        public string OvallStateName { get; private set; }
        [Column("Model Name")]
        public string ModelName { get; private set; }
        [Column("State")]
        public string WorkingState { get; private set; }
        [Column("Plate Number")]
        public string PlateNumber { get; private set; }
    }
}
