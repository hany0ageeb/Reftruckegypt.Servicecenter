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
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string IsEnabled { get; private set; }
    }
}
