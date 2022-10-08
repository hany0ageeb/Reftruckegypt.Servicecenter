using System;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Vehicle : EntityBase
    {
        public virtual VehicleCategory VehicleCategory { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public string ChassisNumber { get; set; }
        // For SpeedViolation Report
        public string VehicelCode { get; set; }
        public string InternalCode { get; set; }
        public virtual FuelCard FuelCard { get; set; }
        public virtual VehicleOvallState OvallState { get; set; }
        public Guid? OverallStateId { get; set; }
        public Guid VehicleCategoryId { get; set; }
        public Guid VehicelModelId { get; set; }
        public string WorkingState { get; set; } = VehicleStates.Working;
        public virtual Location WorkLocation { get; set; }
        public virtual FuelType FuelType { get; set; }
        public Guid FuelTypeId { get; set; }
        public Guid? WorkLocationId { get; set; }
        public virtual Location MaintenanceLocation { get; set; }
        public Guid? MaintenanceLocationId { get; set; }
        public virtual ICollection<VehicleLicense> VehicelLicenses { get; set; } = new HashSet<VehicleLicense>();
        public virtual Driver Driver { get; set; }
        public Guid? DriverId { get; set; }
        public int ModelYear { get; set; } = DateTime.Now.Year;

        public Vehicle Self => this;
    }
   
    public static class VehicleStates
    {
        public const string Broken = "Broken";
        public const string Working = "Working";

        public static bool IsValidState(string state)
        {
            return state == Broken || state == Working;
        }
    }
}
