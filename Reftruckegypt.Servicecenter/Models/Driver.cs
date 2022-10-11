using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Driver : EntityBase
    {
        public string Name { get; set; }
        [Npoi.Mapper.Attributes.Column("License Number")]
        public string LicenseNumber { get; set; }
        [Npoi.Mapper.Attributes.Column("Traffic Department Name")]
        public string TrafficDepartmentName { get; set; }
        [Npoi.Mapper.Attributes.Column("License End Date")]
        public DateTime LicenseEndDate { get; set; } = DateTime.Now;
        [Npoi.Mapper.Attributes.Column("Enabled")]
        public bool IsEnabled { get; set; } = true;
        [Npoi.Mapper.Attributes.Ignore()]
        public Driver Self => this;

        public readonly static Driver Empty = new Driver() { Id = Guid.Empty, Name = "" };

        public const int MaxNameLength = 250;

        public const int MaxLicenseNumberLength = 250;

        public const int MaxTrafficDepartmentNameLength = 250;

    }
}
