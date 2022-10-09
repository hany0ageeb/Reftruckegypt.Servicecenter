using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class VehicleOverAllState : EntityBase
    {
        public VehicleOverAllState Self => this;
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; } = true;

        public readonly static VehicleOverAllState Empty = new VehicleOverAllState() { Id = Guid.Empty, Name = ""};

        public const int MaxNameLength = 250;
        public const int MaxDescriptionLength = 500;
    }
}
