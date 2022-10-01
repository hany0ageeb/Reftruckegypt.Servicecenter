using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models
{
    public class ExternalAutoRepairShop : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<ExternalRepairBill> ExternalRepairBills { get; set; } = new HashSet<ExternalRepairBill>();
        public bool IsEnabled { get; set; } = true;
    }
}
