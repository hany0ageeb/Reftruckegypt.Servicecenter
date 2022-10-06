namespace Reftruckegypt.Servicecenter.Models
{
    public class Uom : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true;

        public Uom Self => this;

        public const int CodeMaxLength = 8;
        public const int NameMaxLength = 250;
    }
}
