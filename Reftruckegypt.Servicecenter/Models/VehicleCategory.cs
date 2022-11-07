using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models
{
    public class VehicleCategory : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFuelCardRequired { get; set; } = true;
        public bool IsChassisNumberRequired { get; set; } = true;
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
        public static readonly VehicleCategory empty = new VehicleCategory() { Id = System.Guid.Empty, Name = "" };
        public VehicleCategory Self => this;
        public const int MaxVehicleCategoryNameLength = 250;
        public const int MaxVehicleCategoryDescriptionLength = 500;
    }
}
