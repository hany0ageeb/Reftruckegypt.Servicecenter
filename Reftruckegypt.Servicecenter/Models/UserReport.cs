using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class UserReport : EntityBase
    {
        public int Sequence { get; set; } = 10;
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsEnabled { get; set; } = true;
        public string ParameterViewTypeName { get; set; }
        public Action Execute { get; set; } = () =>
        {

        };
        public const int MaxDisplayNameLength = 500;
        public const int MaxNameLength = 250;
    }
}
