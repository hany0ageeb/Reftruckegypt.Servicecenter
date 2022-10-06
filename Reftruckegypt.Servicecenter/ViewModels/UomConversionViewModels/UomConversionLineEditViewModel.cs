using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.UomConversionViewModels
{
    public class UomConversionLineEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private SparePart _sparePart;
        private Uom _fromUom;
        private Uom _toUom;
        private decimal _rate;
        private string _notes;
        public IValidator<UomConversion> Validator { get; set; }
        public UomConversionLineEditViewModel()
        {
            Id = Guid.Empty;
        }
        public UomConversionLineEditViewModel(UomConversion uomConversion)
        {
            Id = uomConversion.Id;
            _sparePart = uomConversion.SparePart;
            _fromUom = uomConversion.FromUom;
            _toUom = uomConversion.ToUom;
            _notes = uomConversion.Notes;
            _rate = uomConversion.Rate;
        }
        public Guid Id { get; private set; }
        public SparePart SparePart
        {
            get => _sparePart;
            set
            {
                if (_sparePart != value)
                {
                    _sparePart = value;
                    Validate();
                    OnPropertyChanged(this, nameof(SparePart));
                }
            }
        }
        public Uom FromUom
        {
            get => _fromUom;
            set
            {
                if (_fromUom != value)
                {
                    _fromUom = value;
                    _ = Validate();
                    OnPropertyChanged(this, nameof(FromUom));
                }
            }
        }
        public Uom ToUom
        {
            get => _toUom;
            set
            {
                if (_toUom != value)
                {
                    _toUom = value;
                    _ = Validate();
                    OnPropertyChanged(this, nameof(ToUom));
                }
            }
        }
        public decimal Rate
        {
            get => _rate;
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                    _ = Validate();
                    OnPropertyChanged(this, nameof(Rate));
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
                    _ = Validate();
                    OnPropertyChanged(this, nameof(Notes));
                }
            }
        }
        public UomConversion UomConversion => new UomConversion()
        {
            Id = Id,
            FromUom = _fromUom,
            ToUom = _toUom,
            Rate = _rate,
            Notes = _notes,
            SparePart = _sparePart
        };
        public ModelState Validate(bool notify = false)
        {
            _modelState.Clear();
            var modelState = Validator.Validate(UomConversion);
            _modelState.AddErrors(modelState);
            if (notify)
                OnPropertyChanged(this, nameof(SparePart));
            return modelState;
        }
        private readonly ModelState _modelState = new ModelState();
        #region IDataErrorInfo
        public string this[string columnName] => _modelState[columnName];
        public string Error => _modelState.Error;
        #endregion IDataErrorInfo
    }
}
