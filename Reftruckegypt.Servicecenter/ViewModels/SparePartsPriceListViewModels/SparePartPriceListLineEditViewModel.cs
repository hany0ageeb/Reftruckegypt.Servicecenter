using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartsPriceListViewModels
{
    public class SparePartPriceListLineEditViewModel : ViewModelBase, IDataErrorInfo
    {
        public  IValidator<SparePartPriceListLine> Validator { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
        private SparePart _sparePart;
        private Uom _uom;
        private decimal _unitPrice;
        private decimal? _conversionRate;
        public SparePartPriceListLineEditViewModel()
            : this(null)
        {

        }
        public SparePartPriceListLineEditViewModel(SparePartPriceListLine line)
        {
            if (line != null)
            {
                Id = line.Id;
                _sparePart = line.SparePart;
                _uom = line.Uom;
                _unitPrice = line.UnitPrice;
                _conversionRate = line.UomConversionRate;
            }
            else
            {
                Id = Guid.Empty;
                _unitPrice = 0;
            }
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
            private set
            {
                if (_conversionRate != value)
                {
                    _conversionRate = value;
                    OnPropertyChanged(this, nameof(UomConversionRate));
                }
            }
        }
        public SparePartPriceListLine SparePartPriceListLine
        {
            get
            {
                return new SparePartPriceListLine()
                {
                    Id = Id,
                    SparePart = _sparePart,
                    Uom = _uom,
                    UnitPrice = _unitPrice,
                    UomConversionRate = _conversionRate
                };
            }
        }
        public ModelState Validate(bool notify = false)
        {
            ModelState modelState = new ModelState();
            if (_sparePart != null && _uom != null)
            {
                if(_sparePart.PrimaryUom.Id != _uom.Id && _conversionRate == null)
                {
                    _conversionRate = UnitOfWork.UomConversionRepository.FindUomConversionRate(_uom.Id, _sparePart.PrimaryUom.Id, _sparePart.Id);
                }
            }
            modelState.AddErrors(Validator.Validate(SparePartPriceListLine));
            if(modelState.HasErrors && notify)
            {
                OnPropertyChanged(this, nameof(SparePart));
            }
            return modelState;
        }
        #region IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                return Validate()[columnName];
            }
        }
        public string Error
        {
            get
            {
                return Validate().Error;
            }
        }
        #endregion IDataErrorInfo
    }
}
