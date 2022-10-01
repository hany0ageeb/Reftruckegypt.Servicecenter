using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Driver : EntityBase
    {
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public string TrafficDepartmentName { get; set; }
        public DateTime LicenseEndDate { get; set; }

    }
}
