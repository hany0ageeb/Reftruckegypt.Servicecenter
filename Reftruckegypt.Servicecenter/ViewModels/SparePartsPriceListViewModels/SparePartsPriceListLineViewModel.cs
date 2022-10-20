using Npoi.Mapper.Attributes;
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
            Number = priceListLine.SparePartsPriceList.Number;
            Name = priceListLine.SparePartsPriceList.Name;
            FromDate = priceListLine.SparePartsPriceList.Period.FromDate;
            ToDate = priceListLine.SparePartsPriceList.Period.ToDate;
            SparePartCode = priceListLine.SparePart.Code;
            SparePartName = priceListLine.SparePart.Name;
            UomCode = priceListLine.Uom.Code;
            UnitPrice = priceListLine.UnitPrice;
            State = priceListLine.SparePartsPriceList.Period.State;
            ConversionRate = priceListLine.UomConversionRate;
        }
        public SparePartsPriceListLineViewModel()
        {

        }
       [Ignore]
        public Guid Id { get;  set; }
        [Ignore]
        public Guid ListId { get;  set; }
        public long Number { get;  set; }
        [Column("Price List Name")]
        public string Name { get;  set; }
        [Column("From Date")]
        public DateTime FromDate { get;  set; }
        [Column("To Date")]
        public DateTime ToDate { get;  set; }
        public string State { get;  set; }
        [Column("Period Name")]
        public string PeriodName { get; set; }
        [Column("Spare Part Code")]
        public string SparePartCode { get;  set; }
        [Column("Spare Part Name")]
        public string SparePartName { get;  set; }
        [Column("Uom Code")]
        public string UomCode { get; private set; }
        [Column("Unit Price")]
        public decimal UnitPrice { get; private set; }
        [Column("Uom Conversion Rate")]
        public decimal? ConversionRate { get; private set; }
    }
}
