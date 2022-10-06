using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels
{
    public class FuelConsumptionViewModel
    {
        public FuelConsumptionViewModel(FuelConsumption fuelConsumption)
        {
            Id = fuelConsumption.Id;
            State = fuelConsumption.Period.State;
            Notes = fuelConsumption.Notes;
            ConsumptionDate = fuelConsumption.ConsumptionDate;
            FuelCardNumber = fuelConsumption.FuelCard.Number;
            FuelCardName = fuelConsumption.FuelCard.Name;
            FuelTypeName = fuelConsumption.FuelType.Name;
            QuantityInLiters = fuelConsumption.TotalConsumedQuanityInLiteres;
            AmountInEGP = fuelConsumption.TotalAmountInEGP;
        }
        public Guid Id { get; private set; }
        public string State { get; private set; }
        public string VehicleInternalCode { get; private set; }
        public string FuelCardNumber { get; private set; }
        public string FuelCardName { get; private set; }
        public DateTime ConsumptionDate { get; private set; }
        public decimal QuantityInLiters { get; private set; }
        public string FuelTypeName { get; private set; }
        public decimal AmountInEGP { get; private set; }
        public string Notes { get; private set; }
    }
}
