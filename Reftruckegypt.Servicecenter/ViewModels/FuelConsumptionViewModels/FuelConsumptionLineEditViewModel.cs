using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels
{
    public class FuelConsumptionLineEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private Vehicle _vehicle;
        private FuelCard _fuelCard;
        private FuelType _fuelType;
        private decimal _quantity = 1;
        private decimal _amount = 0;
        private DateTime _consumptionDate;
        private Period _period;
        private string _notes;

        private bool _hasChanged = false;
        public IValidator<FuelConsumption> Validator { get; set; }
        public FuelConsumptionLineEditViewModel()
            : this(null, null)
        {
           
        }
        public FuelConsumptionLineEditViewModel(
            FuelConsumption fuelConsumption, 
            IValidator<FuelConsumption> validator)
        {
            Validator = validator;
            if (fuelConsumption != null)
            {
                Id = fuelConsumption.Id;
                _vehicle = fuelConsumption.Vehicle;
                _fuelCard = fuelConsumption.FuelCard;
                _fuelType = fuelConsumption.FuelType;
                _amount = fuelConsumption.TotalAmountInEGP;
                _quantity = fuelConsumption.TotalConsumedQuanityInLiteres;
                _notes = FuelConsumption.Notes;
            }
            else
            {
                Id = Guid.Empty;
                _notes = "";
                _quantity = 1;
                _amount = 0;
            }
        }
        public Guid Id { get; private set; }
        public bool HasChanged
        {
            get => _hasChanged;
            set
            {
                if (_hasChanged != value)
                {
                    _hasChanged = value;
                }
            }
        }
        public Vehicle Vehicle
        {
            get => _vehicle;
            set
            {
                if (_vehicle != value)
                {
                    _vehicle = value;
                    _fuelCard = value.FuelCard;
                    _fuelType = value.FuelType;
                    OnPropertyChanged(this, nameof(Vehicle));
                    OnPropertyChanged(this, nameof(FuelType));
                    OnPropertyChanged(this, nameof(FuelCard));
                }
            }
        }
        public FuelCard FuelCard
        {
            get => _fuelCard;
            set
            {
                if (_fuelCard != value)
                {
                    _fuelCard = value;
                    OnPropertyChanged(this, nameof(FuelCard));
                }
            }
        }
        public FuelType FuelType
        {
            get => _fuelType;
            set
            {
                if (_fuelType != value)
                {
                    _fuelType = value;
                    OnPropertyChanged(this, nameof(FuelType));
                }
            }
        }
        public decimal TotalConsumedQuantityInLiteres
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(this, nameof(TotalConsumedQuantityInLiteres));
                    HasChanged = true;
                }
            }
        }
        public decimal TotalAmountInEGP
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(this, nameof(TotalAmountInEGP));
                    HasChanged = true;
                }
            }
        }
        public DateTime ConsumptionDate
        {
            get => _consumptionDate;
            set
            {
                if (_consumptionDate != value)
                {
                    _consumptionDate = value;
                    OnPropertyChanged(this, nameof(ConsumptionDate));
                    HasChanged = true;
                }
            }
        }
        public Period Period
        {
            get => _period;
            set
            {
                if (_period != value)
                {
                    _period = value;
                    OnPropertyChanged(this, nameof(Period));
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
        public FuelConsumption FuelConsumption => new FuelConsumption()
        {
            Id = Id,
            Vehicle = _vehicle,
            FuelCard = _fuelCard,
            FuelType = _fuelType,
            Notes = _notes,
            ConsumptionDate = _consumptionDate,
            Period = _period,
            TotalAmountInEGP = _amount,
            TotalConsumedQuanityInLiteres = _quantity
        };
        public ModelState Validate(bool notify = false)
        {
            ModelState modelState = new ModelState();
            if (_hasChanged) 
            {
                modelState.AddErrors(Validator.Validate(FuelConsumption));
                if (notify)
                {
                    OnPropertyChanged(this, nameof(Vehicle));
                }
            }
            return modelState;
        }
        #region IDataErrorInfo
        public string Error => Validate().Error;
        public string this[string columnName] => Validate()[columnName];
        #endregion IDataErrorInfo
    }
}
