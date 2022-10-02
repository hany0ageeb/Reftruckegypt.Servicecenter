namespace Reftruckegypt.Servicecenter.Models
{
    public class FuelType : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public const int MaxFuelTypeNameLength = 250;
        public const int MaxFuelTypeDescriptionLength = 500;
    }
}
