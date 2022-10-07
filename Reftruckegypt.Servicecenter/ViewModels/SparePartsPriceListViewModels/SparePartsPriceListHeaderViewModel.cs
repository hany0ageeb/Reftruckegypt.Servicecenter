using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartsPriceListViewModels
{
    public class SparePartsPriceListHeaderViewModel
    {
        public SparePartsPriceListHeaderViewModel(SparePartsPriceList priceList)
        {
            Id = priceList.Id;
            Name = priceList.Name;
            FromDate = priceList.Period.FromDate;
            ToDate = priceList.Period.ToDate;
            State = priceList.Period.State;
        }
        public Guid Id { get; private set; }
        public long Number { get; private set; }
        public string Name { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public string State { get; private set; }
    }
}
