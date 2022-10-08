using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels
{
    public class SparePartsBillLineEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private SparePart _sparePart;
        private Uom _uom;
        private decimal _quantity;
        private decimal _unitPrice;
        private string _notes;
        private decimal? _conversionRate;
        public SparePartsBillLineEditViewModel()
        {

        }
        public SparePartsBillLineEditViewModel(SparePartsBillLine line)
        {
            if (line != null)
            {
                Id = line.Id;
                _sparePart = line.SparePart;
                _quantity = line.Quantity;
                _uom = line.Uom;
            }
            else
            {
                Id = Guid.Empty;
                _quantity = 1;
            }
        }
        public IValidator<SparePartsBillLine> Validator { get; set; }
        public Guid Id { get; private set; }
        public SparePart SparePart
        {
            get => _sparePart;
            set
            {
                if (_sparePart != value)
                {
                    _sparePart = value;
                    OnPropertyChanged(this, nameof(SparePart));
                }
            }
        }
        public Uom Uom
        {
            get => _uom;
            set
            {
                if (_uom != value)
                {
                    _uom = value;
                    OnPropertyChanged(this, nameof(Uom));
                }
            }
        }
        public decimal Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(this, nameof(Quantity));
                }
            }
        }
        public decimal UnitPrice
        {
            get => _unitPrice;
            set
            {
                if (_unitPrice != value)
                {
                    _unitPrice = value;
                    OnPropertyChanged(this, nameof(UnitPrice));
                }
            }
        }
        public decimal? UomConversionRate
        {
            get => _conversionRate;
            set
            {
                if (_conversionRate != value)
                {
                    _conversionRate = value;
                    OnPropertyChanged(this, nameof(UomConversionRate));
                }
            }
        }
        public string Notes
        {
            get => _notes;
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    OnPropertyChanged(this, nameof(Notes));
                }
            }
        }
        public SparePartsBillLine SparePartsBillLine => new SparePartsBillLine()
        {
            Id = Id,
            SparePart = _sparePart,
            Quantity = _quantity,
            Uom = _uom,
            Notes = _notes
        };
        public ModelState Validate(bool notify = false)
        {
            return Validator.Validate(SparePartsBillLine);
        }
        
        #region IDataErrorInfo
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
        #endregion IDataErrorInfo
    }
}
