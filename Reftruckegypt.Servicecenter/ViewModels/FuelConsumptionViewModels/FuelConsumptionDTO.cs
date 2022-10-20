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
}
