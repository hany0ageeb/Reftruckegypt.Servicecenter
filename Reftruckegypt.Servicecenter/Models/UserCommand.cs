using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class UserCommand : EntityBase
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        
        public Action Execute { get; set; }

        public UserCommand Self => this;
    }
}
