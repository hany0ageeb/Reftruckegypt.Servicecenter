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
            Name = priceListLine.SparePartsPriceList.Name;
            FromDate = priceListLine.SparePartsPriceList.Period.FromDate;
            ToDate = priceListLine.SparePartsPriceList.Period.ToDate;
            SparePartCode = priceListLine.SparePart.Code;
            SparePartName = priceListLine.SparePart.Name;
            UomCode = priceListLine.Uom.Code;
            UnitPrice = priceListLine.UnitPrice;
            State = priceListLine.SparePartsPriceList.Period.State;
        }
        [Ignore]
        public Guid Id { get; private set; }
        [Ignore]
        public Guid ListId { get; private set; }
        public long Number { get; private set; }
        public string Name { get; private set; }
        [Column("From Date")]
        public DateTime FromDate { get; private set; }
        [Column("To Date")]
        public DateTime ToDate { get; private set; }
        public string State { get; private set; }
        [Column("Spare Part Code")]
        public string SparePartCode { get; private set; }
        [Column("Spare Part Name")]
        public string SparePartName { get; private set; }
        [Column("Uom Code")]
        public string UomCode { get; private set; }
        [Column("Unit Price")]
        public decimal UnitPrice { get; private set; }
    }
}
