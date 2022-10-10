using Npoi.Mapper.Attributes;
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
        [Ignore]
        public Guid Id { get; private set; }
        [Column("Vehicle Internal Code")]
        public string VehicleInternalCode { get; private set; }
        [Column("From Date")]
        public DateTime FromDate { get; private set; }
        [Column("To Date")]
        public DateTime? ToDate { get; private set; }
        public string Notes { get; private set; }
        [Ignore]
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
