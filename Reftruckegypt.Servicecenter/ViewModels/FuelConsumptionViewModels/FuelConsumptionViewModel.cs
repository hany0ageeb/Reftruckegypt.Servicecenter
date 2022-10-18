using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels
{
    public class FuelConsumptionDTO
    {
        public string FuelCardNumber { get; set; }
        public string QuantityConsumed { get; set; }
        public string AmountConsumed { get; set; }
        public DateTime FuelConsumptionDate { get; set; }
    }
    public class FuelConsumptionViewModel
    {
        public FuelConsumptionViewModel(FuelConsumption fuelConsumption)
        {
            Id = fuelConsumption.Id;
            State = fuelConsumption.Period.State;
            Notes = fuelConsumption.Notes;
            ConsumptionDate = fuelConsumption.ConsumptionDate;
            VehicleInternalCode = fuelConsumption.Vehicle.InternalCode;
            FuelCardNumber = fuelConsumption.FuelCard.Number;
            FuelCardName = fuelConsumption.FuelCard.Name;
            FuelTypeName = fuelConsumption.FuelType.Name;
            QuantityInLiters = fuelConsumption.TotalConsumedQuanityInLiteres;
            AmountInEGP = fuelConsumption.TotalAmountInEGP;
            VehicleCategoryName = fuelConsumption.Vehicle.VehicleCategory?.Name;
            VehicleModelName = fuelConsumption.Vehicle.VehicleModel?.Name;
        }
        public FuelConsumptionViewModel()
        {

        }
        [Ignore]
        public Guid Id { get; private set; }
        [Column("State")]
        public string State { get; private set; }
        [Column("Vehicle Internal Code")]
        public string VehicleInternalCode { get; private set; }
        [Column("Vehicle Category Name")]
        public string VehicleCategoryName { get; private set; }
        [Column("Vehicle Model Name")]
        public string VehicleModelName { get; private set; }
        [Column("Fuel Card Number")]
        public string FuelCardNumber { get; private set; }
        [Column("Fuel Card Name")]
        public string FuelCardName { get; private set; }
        [Column("Consumption Date")]
        public DateTime ConsumptionDate { get; private set; }
        [Column("Quantity In Liters")]
        public decimal QuantityInLiters { get; private set; }
        [Column("Fuel Type")]
        public string FuelTypeName { get; private set; }
        [Column("Amount In EGP")]
        public decimal AmountInEGP { get; private set; }
        [Column("Notes")]
        public string Notes { get; private set; }

    }
}
