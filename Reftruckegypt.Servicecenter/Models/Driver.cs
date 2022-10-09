using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Driver : EntityBase
    {
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public string TrafficDepartmentName { get; set; }
        public DateTime LicenseEndDate { get; set; }
        public bool IsEnabled { get; set; } = true;
        public Driver Self => this;

        public readonly static Driver Empty = new Driver() { Id = Guid.Empty, Name = "" };

        public const int MaxNameLength = 250;

        public const int MaxLicenseNumberLength = 250;

        public const int MaxTrafficDepartmentNameLength = 250;

    }
}
