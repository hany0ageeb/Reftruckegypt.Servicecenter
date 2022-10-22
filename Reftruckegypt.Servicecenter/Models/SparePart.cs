using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class SparePart : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual Uom PrimaryUom { get; set; }
        public Guid PrimaryUomId { get; set; }
        public bool IsEnabled { get; set; } = true;
        public SparePart Self => this;
        public static readonly SparePart empty = new SparePart() { Id = Guid.Empty, Code = "" , Name = ""};
        public const int MaxSparePartCodeLength = 100;
        public const int MaxSparePartNameLength = 500;
    }
}
