using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleKilometerReadingViewModels
{
    public class VehicleKilometerReadingViewModel
    {
        public VehicleKilometerReadingViewModel(VehicleKilometerReading kilometerReading)
        {
            Id = kilometerReading.Id;
            VehicleInternalCode = kilometerReading.Vehicle.InternalCode;
            ReadingDate = kilometerReading.ReadingDate;
            Reading = kilometerReading.Reading;
            Notes = kilometerReading.Notes;
            State = kilometerReading.Period.State;
        }
        public VehicleKilometerReadingViewModel()
        {

        }
        [Ignore()]
        public Guid Id { get; private set; }
        [Column("Vehicle Internal Code")]
        public string VehicleInternalCode { get; private set; }
        [Column("Reading Date")]
        public DateTime ReadingDate { get; private set; }
        [Column("Reading")]
        public decimal Reading { get; private set; }
        [Column("Notes")]
        public string Notes { get; private set; }
        [Column("State")]
        public string State { get; private set; }
    }
}
