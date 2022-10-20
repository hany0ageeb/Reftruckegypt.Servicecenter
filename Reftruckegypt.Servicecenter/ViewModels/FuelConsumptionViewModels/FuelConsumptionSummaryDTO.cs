namespace Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels
{
    public class FuelConsumptionSummaryDTO
    {
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string Registration { get; set; }
        public decimal QuantityConsumed { get; set; }
        public decimal AmountConsumed { get; set; }
        public decimal StartKilometerReading { get; set; }
        public decimal EndKilometerReading { get; set; }
        public string VehicleCategory { get; set; }
        public string VehicleInternalCode { get; set; }
        public string FuelTypeName { get; set; }
    }
}
