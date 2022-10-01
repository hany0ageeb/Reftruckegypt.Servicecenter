using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class SparePart : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Uom PrimaryUom { get; set; }
        public Guid PrimaryUomId { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
