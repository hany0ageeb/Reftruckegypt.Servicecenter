using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class VehicleModel : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual FuelType DefaultFuelType { get; set;}
        public Guid? DefaultFuelTypeId { get; set; }

        public const int NameMaxLength = 250;
        public const int DescriptionMaxLength = 500;
    }
}
