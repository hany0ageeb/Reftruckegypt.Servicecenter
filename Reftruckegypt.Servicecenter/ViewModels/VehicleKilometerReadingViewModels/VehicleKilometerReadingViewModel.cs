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
        public Guid Id { get; private set; }
        public string VehicleInternalCode { get; private set; }
        public DateTime ReadingDate { get; private set; }
        public decimal Reading { get; private set; }
        public string Notes { get; private set; }
        public string State { get; private set; }
    }
}
