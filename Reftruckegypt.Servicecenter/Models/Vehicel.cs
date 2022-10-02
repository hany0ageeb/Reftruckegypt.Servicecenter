using System;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Vehicle : EntityBase
    {
        public VehicleCategory VehicleCategory { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public string ChassisNumber { get; set; }
        // For SpeedVilation Report
        public string VehicelCode { get; set; }
        public FuelCard FuelCard { get; set; }
        public Guid? FuelCardId { get; set; }
        public VehicelOvallState OvallState { get; set; }
        public Guid? OverallStateId { get; set; }
        public Guid VehicleCategoryId { get; set; }
        public Guid VehicelModelId { get; set; }
        public string WorkingState { get; set; } = VehicleStates.Working;
        public Location WorkLocation { get; set; }
        public Guid? WorkLocationId { get; set; }
        public Location MaintenanceLocation { get; set; }
        public Guid? MaintenanceLocationId { get; set; }
        public virtual ICollection<VehicelLicense> VehicelLicenses { get; set; } = new HashSet<VehicelLicense>();
        public Driver Driver { get; set; }
        public Guid? DriverId { get; set; }
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
