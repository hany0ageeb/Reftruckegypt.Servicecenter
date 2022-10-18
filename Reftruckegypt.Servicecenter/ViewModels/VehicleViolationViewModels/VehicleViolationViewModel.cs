using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels
{
    public class VehicleViolationViewModel
    {
        public VehicleViolationViewModel(VehicleViolation violation)
        {
            Id = violation.Id;
            State = violation.Period.State;
            VehicleInternalCode = violation.Vehicle.InternalCode;
            VehicleCode = violation.Vehicle.VehicleCode;
            VehiclePlateNumber = violation.Vehicle.VehicelLicenses.OrderByDescending(x => x.StartDate).FirstOrDefault()?.PlateNumber;
            ViolationDate = violation.ViolationDate;
            ViolationTypeName = violation.ViolationType.Name;
            Notes = violation.Notes;
            Count = violation.Count;
        }
        public VehicleViolationViewModel()
        {

        }
        [Ignore]
        public Guid Id { get; private set; }
        public string State { get; private set; }
        [Column("Vehicle Internal Code")]
        public string VehicleInternalCode { get; set; }
        [Column("Vehicle Code")]
        public string VehicleCode { get; set; }
        [Column("Plate Number")]
        public string VehiclePlateNumber { get; set; }
        [Column("Violation Date")]
        public DateTime ViolationDate { get; private set; }
        [Column("Violation Type")]
        public string ViolationTypeName { get; private set; }
        public string Notes { get; private set; }
        [Column("Number Of Violations")]
        public int Count { get;  set; }
    }
}
