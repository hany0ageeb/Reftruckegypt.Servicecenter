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

        private ModelState _modelState = new ModelState();
        private IValidator<FuelConsumption> _validator = new FuelConsumptionValidator();
        public FuelConsumptionLineEditViewModel()
        {
            Id = Guid.Empty;
            _notes = "";
        }
        public FuelConsumptionLineEditViewModel(FuelConsumption fuelConsumption)
        {
            Id = fuelConsumption.Id;
            _vehicle = fuelConsumption.Vehicle;
            _fuelCard = fuelConsumption.FuelCard;
            _fuelType = fuelConsumption.FuelType;
            _amount = fuelConsumption.TotalAmountInEGP;
            _quantity = fuelConsumption.TotalConsumedQuanityInLiteres;
            _notes = FuelConsumption.Notes;
        }
        public Guid Id { get; private set; }
        public Vehicle Vehicle
        {
            get => _vehicle;
            set
            {
                if (_vehicle != value)
                {
                    _vehicle = value;
                    OnPropertyChanged(this, nameof(Vehicle));
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
        public FuelConsumption FuelConsumption => new FuelConsumption()
        {
            Id = Id,
            Vehicle = Vehicle,
            FuelCard = FuelCard,
            FuelType = FuelType,
            Notes = Notes,
            ConsumptionDate = ConsumptionDate,
            Period = Period,
            TotalAmountInEGP = TotalAmountInEGP,
            TotalConsumedQuanityInLiteres = TotalConsumedQuantityInLiteres
        };
        public ModelState Validate(bool notify = false)
        {
            ModelState modelState = _validator.Validate(FuelConsumption);
            _modelState.Clear();
            _modelState.AddErrors(modelState);
            if (notify)
            {
                OnPropertyChanged(this, nameof(Vehicle));
            }
            return modelState;
        }
        #region IDataErrorInfo
        public string Error => _modelState.Error;
        public string this[string columnName] => _modelState[columnName];
        #endregion IDataErrorInfo
    }
}
