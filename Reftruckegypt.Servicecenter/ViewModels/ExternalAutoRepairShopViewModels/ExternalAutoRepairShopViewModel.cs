using Npoi.Mapper.Attributes;
using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.ExternalAutoRepairShopViewModels
{
    public class ExternalAutoRepairShopViewModel
    {
        public ExternalAutoRepairShopViewModel(ExternalAutoRepairShop shop)
        {
            Id = shop.Id;
            Name = shop.Name;
            Address = shop.Address;
            Phone = shop.Phone;
            IsEnabled = shop.IsEnabled ? "Yes" : "No";
        }
        [Ignore]
        public Guid Id { get; private set; }
        [Column("Repair Shop Name")]
        public string Name { get; private set; }
        [Column("Repair Shop Address")]
        public string Address { get; private set; }
        [Column("Repair Shop Phone")]
        public string Phone { get; private set; }
        [Column("Enabled")]
        public string IsEnabled { get; private set; }
    }
}
