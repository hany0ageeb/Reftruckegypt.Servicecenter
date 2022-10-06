using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class UserCommand : EntityBase
    {
        public int Sequence { get; set; } = 10;
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsEnabled { get; set; } = true;
        public Action Execute { get; set; }
        public UserCommand Self => this;
    }
}
