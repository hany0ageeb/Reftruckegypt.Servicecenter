namespace Reftruckegypt.Servicecenter.Models
{
    public class VehicleCategory : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFuelCardRequired { get; set; } = true;
        public bool IsChassisNumberRequired { get; set; } = true;

        public const int MaxVehicleCategoryNameLength = 250;
        public const int MaxVehicleCategoryDescriptionLength = 500;
    }
}
