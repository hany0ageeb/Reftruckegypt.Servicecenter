using System;
using System.Collections.Generic;
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
            DriverName = vehicle.Driver?.Name ?? "";
            FuelCardNumber = vehicle.FuelCard?.Number ?? "";
            FuelCardName = vehicle.FuelCard?.Name ?? "";
            Registration = vehicle.FuelCard?.Registration ?? "";
            FuelTypeName = vehicle.FuelType?.Name;
            MaintenanceLocationName = vehicle.MaintenanceLocation?.Name ?? "";
            WorkingLocationName = vehicle.WorkLocation?.Name ?? "";
            ModelYear = vehicle.ModelYear;
            VehicleCategoryName = vehicle?.VehicleCategory?.Name ?? "";
            OvallStateName = vehicle.OverAllState?.Name;
            ModelName = vehicle.VehicleModel?.Name;
            WorkingState = vehicle.WorkingState;
            if(vehicle.VehicelLicenses.Count > 0)
            {
                var orderLicenses = vehicle.VehicelLicenses.OrderByDescending(l => l.EndDate).ToList();
                PlateNumber = orderLicenses[0].PlateNumber;
                MotorNumber = orderLicenses[0].MotorNumber;
                StartDate = orderLicenses[0].StartDate;
                EndDate = orderLicenses[0].EndDate;
            }
            else
            {
                PlateNumber = "";
                MotorNumber = "";
                StartDate = null;
                EndDate = null;
            }
            
        }
        public VehicleViewModel()
        {

        }
        [Ignore]
        public Guid Id { get;  set; }
        [Column("Internal Code")]
        public string InternalCode { get;  set; }
        [Column("Chassis Number")]
        public string ChassisNumber { get;  set; }
        [Column("Driver Name")]
        public string DriverName { get;  set; }
        [Column("Fuel Card Number")]
        public string FuelCardNumber { get;  set; }
        [Column("Fuel Card Name")]
        public string FuelCardName { get; set; }
        [Column("Fuel Type Name")]
        public string FuelTypeName { get;  set; }
        [Column("Registration")]
        public string Registration { get; set; }
        [Column("Maintenance Location")]
        public string MaintenanceLocationName { get;  set; }
        [Column("Working Location")]
        public string WorkingLocationName { get;  set; }
        [Column("Model Year")]
        public int ModelYear { get;  set; }
        [Column("Over all State")]
        public string OvallStateName { get;  set; }
        [Column("Model Name")]
        public string ModelName { get;  set; }
        [Column("State")]
        public string WorkingState { get;  set; }
        [Column("Plate Number")]
        public string PlateNumber { get;  set; }
        [Column("Motor Number")]
        public string MotorNumber { get; set; }
        [Column("Start Date")]
        public DateTime? StartDate { get; set; }
        [Column("End Date")]
        public DateTime? EndDate { get; set; }
        [Column ("Vehicle Code In GPS")]
        public string VehicleCode { get; set; }
        [Column("Category Name")]
        public string VehicleCategoryName { get; set; }
        public decimal TotalKilometers { get; set; } = 0;
        public List<ExternalRepairBillViewModels.ExternalRepairBillViewModel> ExternalRepairBills { get; private set; } = new List<ExternalRepairBillViewModels.ExternalRepairBillViewModel>();
        public List<FuelConsumptionViewModels.FuelConsumptionViewModel> FuelConsumptions { get; private set; } = new List<FuelConsumptionViewModels.FuelConsumptionViewModel>();
        public List<VehicleKilometerReadingViewModels.VehicleKilometerReadingViewModel> KilometerReadings { get; private set; } = new List<VehicleKilometerReadingViewModels.VehicleKilometerReadingViewModel>();
        public List<SparePartsBillViewModels.SparePartsBillLineViewModel> SparePartsBills { get; private set; } = new List<SparePartsBillViewModels.SparePartsBillLineViewModel>();
    }
}
