using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleStateChangeViewModels
{
    public class VehicleStateChangeViewModel
    {
        public VehicleStateChangeViewModel(VehicleStateChange vehicleStateChange)
        {
            Id = vehicleStateChange.Id;
            VehicleInternalCode = vehicleStateChange.Vehicle.InternalCode;
            FromDate = vehicleStateChange.FromDate;
            ToDate = vehicleStateChange.ToDate;
            Notes = vehicleStateChange.Notes;
            Vehicle = vehicleStateChange.Vehicle;
        }
        public Guid Id { get; private set; }
        public string VehicleInternalCode { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }
        public string Notes { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public VehicleStateChange VehicleStateChange => 
            new VehicleStateChange()
            {
                Id = Id,
                Notes = Notes,
                FromDate = FromDate,
                ToDate = ToDate,
                Vehicle = Vehicle
            };
    }
}
