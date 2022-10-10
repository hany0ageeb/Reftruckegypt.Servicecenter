using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels
{
    public class VehicleViolationViewModel
    {
        public VehicleViolationViewModel(VehicleViolation violation)
        {
            Id = violation.Id;
            State = violation.Period.State;
            VehicleInternalCode = violation.Vehicle.InternalCode;
            ViolationDate = violation.ViolationDate;
            ViolationTypeName = violation.ViolationType.Name;
            Notes = violation.Notes;
            Count = violation.Count;
        }
        [Ignore]
        public Guid Id { get; private set; }
        public string State { get; private set; }
        [Column("Vehicle Internal Code")]
        public string VehicleInternalCode { get; private set; }
        [Column("Violation Date")]
        public DateTime ViolationDate { get; private set; }
        [Column("Violation Type")]
        public string ViolationTypeName { get; private set; }
        public string Notes { get; private set; }
        [Column("Violations Count")]
        public int Count { get; private set; }
    }
}
