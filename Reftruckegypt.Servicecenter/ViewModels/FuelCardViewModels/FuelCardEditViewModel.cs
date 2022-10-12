using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.FuelCardViewModels
{
    public class FuelCardEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private bool _hasChanged = false;
        private IValidator<FuelCard> _validator;
        private readonly FuelCard _fuelCard = new FuelCard();
        public FuelCardEditViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<FuelCard> validator)
            : this(null, unitOfWork, applicationContext, validator)
        {
        }
            public FuelCardEditViewModel(
            FuelCard fuelCard,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<FuelCard> validator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            if (fuelCard != null)
            {
                _fuelCard.Id = fuelCard.Id;
                _fuelCard.Number = fuelCard.Number;
                _fuelCard.Name = fuelCard.Name;
                _fuelCard.Registration = fuelCard.Registration;
                _fuelCard.Vehicle = fuelCard.Vehicle;
                _fuelCard.RowVersion = fuelCard.RowVersion;
                if(fuelCard.Vehicle != null)
                    Vehicles.Add(fuelCard.Vehicle);
                else
                    Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(x => x.FuelCard == null));
            }
            else
            {
                _fuelCard.Id = Guid.Empty;
                _fuelCard.Vehicle = null;
                Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(x => x.FuelCard == null));
            }
        }
        public bool HasChanged
        {
            get => _hasChanged;
            private set
            {
                if (_hasChanged != value)
                {
                    _hasChanged = value;
                    OnPropertyChanged(this, nameof(HasChanged));
                }
            }
        }
        public Guid Id { get; private set; }
        public string Name
        {
            get => _fuelCard.Name;
            set
            {
                if(_fuelCard.Name != value)
                {
                    _fuelCard.Name = value;
                    OnPropertyChanged(this, nameof(Name));
                    HasChanged = true;
                }
            }
        }
        public string Number
        {
            get => _fuelCard.Number;
            set
            {
                if(_fuelCard.Number != value)
                {
                    _fuelCard.Number = value;
                    OnPropertyChanged(this, nameof(Number));
                    HasChanged = true;
                }
            }
        }
        public string Registration
        {
            get => _fuelCard.Registration;
            set
            {
                if(_fuelCard.Registration != value)
                {
                    _fuelCard.Registration = value;
                    OnPropertyChanged(this, nameof(Registration));
                    HasChanged = true;
                }
            }
        }
        public Vehicle Vehicle
        {
            get => _fuelCard.Vehicle;
            set
            {
                if (_fuelCard.Vehicle != value)
                {
                    _fuelCard.Vehicle = value;
                    OnPropertyChanged(this, nameof(Vehicle));
                    HasChanged = true;
                }
            }
        }
        public ModelState Validate()
        {
            ModelState modelState = new ModelState();
            if (_hasChanged)
            {
                modelState.AddErrors(_validator.Validate(_fuelCard));
                if (!modelState.HasErrors)
                {
                    if (_fuelCard.Id == Guid.Empty)
                    {
                        if (_unitOfWork.FuelCardRepository.Exists(x => x.Number == _fuelCard.Number))
                        {
                            modelState.AddError(nameof(_fuelCard.Number), $"Duplicate Fuel Card Number {_fuelCard.Number} already exist.");
                        }
                    }
                    else
                    {
                        if (_unitOfWork.FuelCardRepository.Exists(x => x.Id != _fuelCard.Id && x.Number == _fuelCard.Number))
                        {
                            modelState.AddError(nameof(_fuelCard.Name), $"Duplicate Fuel Card Number {_fuelCard.Number} already exist.");
                        }
                    }
                }
            }
            return modelState;
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                ModelState modelState = Validate();
                if (!modelState.HasErrors)
                {
                    FuelCard fuelCard = FuelCard;
                    if(fuelCard.Id == Guid.Empty)
                    {
                        fuelCard.Id = Guid.NewGuid();
                        _unitOfWork.FuelCardRepository.Add(fuelCard);
                        _unitOfWork.Complete();
                        HasChanged = false;
                        return true;
                    }
                    else
                    {
                        FuelCard oldFuelCard = _unitOfWork.FuelCardRepository.Find(key: fuelCard.Id);
                        if (oldFuelCard != null)
                        {
                            oldFuelCard.Number = fuelCard.Number;
                            oldFuelCard.Name = fuelCard.Name;
                            oldFuelCard.Registration = fuelCard.Registration;
                            oldFuelCard.Vehicle = fuelCard.Vehicle;
                            _unitOfWork.Complete();
                            HasChanged = false;
                            return true;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result = _applicationContext.DisplayMessage(
                    title: "Confrim Save", 
                    message: "Do You Want To Save Changes?", 
                    buttons: MessageBoxButtons.YesNoCancel, 
                    icon: MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    return SaveOrUpdate();
                }
                else if(result == DialogResult.No)
                {
                    HasChanged = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public FuelCard FuelCard => new FuelCard()
        {
            Id = _fuelCard.Id,
            Name = _fuelCard.Name,
            Registration = _fuelCard.Registration,
            Number = _fuelCard.Number,
            Vehicle = _fuelCard.Vehicle,
            RowVersion = _fuelCard.RowVersion
        };
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
    }
}
