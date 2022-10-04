using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models
{
    public class ExternalAutoRepairShop : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsEnabled { get; set; } = true;
        public virtual ICollection<ExternalRepairBill> ExternalRepairBills { get; set; } = new HashSet<ExternalRepairBill>();
        public ExternalAutoRepairShop Self => this;
        public const int MaxNameLength = 250;
        public const int MaxAddressLength = 500;
        public const int MaxPhoneLength = 15;
    }
}
