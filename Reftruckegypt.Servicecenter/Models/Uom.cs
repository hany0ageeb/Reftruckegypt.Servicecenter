using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Uom : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true;
        public virtual ICollection<UomConversion> FromUomConversions { get; set; } = new HashSet<UomConversion>();
        public virtual ICollection<UomConversion> ToUomConversions { get; set; } = new HashSet<UomConversion>();
        public Uom Self => this;

        public const int CodeMaxLength = 8;
        public const int NameMaxLength = 250;
    }
}
