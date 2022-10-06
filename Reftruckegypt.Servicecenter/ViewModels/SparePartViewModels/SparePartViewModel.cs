using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartViewModels
{
    public class SparePartViewModel
    {
        public SparePartViewModel(SparePart sparePart)
        {
            Id = sparePart.Id;
            Code = sparePart.Code;
            Name = sparePart.Name;
            IsEnabled = sparePart.IsEnabled;
            UomCode = sparePart.PrimaryUom.Code;
        }
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string UomCode { get; private set; }
        public bool IsEnabled { get; private set; }
    }
}
