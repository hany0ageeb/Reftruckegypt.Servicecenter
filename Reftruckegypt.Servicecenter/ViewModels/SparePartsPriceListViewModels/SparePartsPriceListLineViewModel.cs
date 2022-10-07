using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartsPriceListViewModels
{
    public class SparePartsPriceListLineViewModel
    {
        public SparePartsPriceListLineViewModel(SparePartPriceListLine priceListLine)
        {
            Id = priceListLine.Id;
            ListId = priceListLine.SparePartsPriceList.Id;
            Name = priceListLine.SparePartsPriceList.Name;
            FromDate = priceListLine.SparePartsPriceList.Period.FromDate;
            ToDate = priceListLine.SparePartsPriceList.Period.ToDate;
            SparePartCode = priceListLine.SparePart.Code;
            SparePartName = priceListLine.SparePart.Name;
            UomCode = priceListLine.Uom.Code;
            UnitPrice = priceListLine.UnitPrice;
            State = priceListLine.SparePartsPriceList.Period.State;
        }
        public Guid Id { get; private set; }
        public Guid ListId { get; private set; }
        public long Number { get; private set; }
        public string Name { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public string State { get; private set; }
        public string SparePartCode { get; private set; }
        public string SparePartName { get; private set; }
        public string UomCode { get; private set; }
        public decimal UnitPrice { get; private set; }
    }
}
