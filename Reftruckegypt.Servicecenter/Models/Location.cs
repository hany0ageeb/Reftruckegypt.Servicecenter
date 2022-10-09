using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Location : EntityBase
    {
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public bool IsEnabled { get; set; } = true;
        public Location Self => this;

        public readonly static Location Empty = new Location() { Id = Guid.Empty, Name = "" };

        public const int MaxNameLength = 250;
        public const int MaxAddressLineLength = 500;
    }
}
