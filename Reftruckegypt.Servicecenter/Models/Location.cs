using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Location
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public byte[] RowVersion { get; set; }
    }
    public class VehicleCategory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFuelCardRequired { get; set; } = true;
        public bool IsChassisNumberRequired { get; set; } = true;
        public byte[] RowVersion { get; set; }

    }
    public class VehicleModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] RowVersion { get; set; }
    }
    public class FuelType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
