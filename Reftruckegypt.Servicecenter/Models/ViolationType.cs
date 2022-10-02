namespace Reftruckegypt.Servicecenter.Models
{
    public class ViolationType : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; } = false;

        public const int MaxNameLength = 250;
        public const int MaxDescriptionLength = 500;
    }
}
