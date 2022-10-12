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
        private decimal _rate = 1;
        private string _notes;
        private bool _hasChanged = false;
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
        public bool HasChanged
        {
            get => _hasChanged;
            private set
            {
                if (_hasChanged != value)
                {
                    _hasChanged = value;
                }
            }
        }
        public SparePart SparePart
        {
            get => _sparePart;
            set
            {
                if (_sparePart != value)
                {
                    _sparePart = value;
                    HasChanged = true;
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
                    OnPropertyChanged(this, nameof(FromUom));
                    HasChanged = true;
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

                    OnPropertyChanged(this, nameof(ToUom));
                    HasChanged = true;
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
                    OnPropertyChanged(this, nameof(Rate));
                    HasChanged = true;
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
                    HasChanged = true;
                }
            }
        }
        public UomConversion UomConversion
        {
            get
            {
                UomConversion uomConversion = new UomConversion()
                {
                    Id = Id,
                    Notes = _notes,
                    Rate = _rate,
                    FromUom = _fromUom,
                    FromUomId = _fromUom.Id,
                    ToUom = _toUom,
                    ToUomId = _toUom.Id
                };
                if(_sparePart == null || _sparePart.Id == Guid.Empty)
                {
                    uomConversion.SparePart = null;
                    uomConversion.SparePartId = null;
                }
                else
                {
                    uomConversion.SparePart = _sparePart;
                    uomConversion.SparePartId = _sparePart.Id;
                }
                return uomConversion;
            }
        }
        public ModelState Validate(bool notify = false)
        {
            ModelState modelState = new ModelState();
            if (_hasChanged)
            {
                modelState.AddErrors (Validator.Validate(UomConversion));
                if (notify && modelState.HasErrors)
                    OnPropertyChanged(this, nameof(SparePart));
            }
            return modelState;
        }
        
        #region IDataErrorInfo
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
        #endregion IDataErrorInfo
    }
}
