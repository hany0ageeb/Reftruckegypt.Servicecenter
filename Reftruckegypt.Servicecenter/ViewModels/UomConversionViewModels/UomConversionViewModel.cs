using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.UomConversionViewModels
{
    public class UomConversionViewModel
    {
        public UomConversionViewModel(UomConversion uomConversion)
        {
            Id = uomConversion.Id;
            SparePartCode = uomConversion.SparePart.Code;
            FromUomCode = uomConversion.FromUom.Code;
            ToUomCode = uomConversion.ToUom.Code;
            ConversionRate = uomConversion.Rate;
            Notes = uomConversion.Notes;
        }
        public Guid Id { get; private set; }
        public string SparePartCode { get; private set; }
        public string FromUomCode { get; private set; }
        public string ToUomCode { get; private set; }
        public decimal ConversionRate { get; private set; }
        public string Notes { get; private set; }
    }
}
