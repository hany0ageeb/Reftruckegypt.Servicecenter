using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleModelViewModels
{
    public class VehicleModelEditViewModel : ViewModelBase, IDisposable, IDataErrorInfo
    {
        private bool _isDisposed = false;
        private string _name;
        private string _description;
        private FuelType _fuelType;
        private readonly IUnitOfWork _unitOfWork;
        private bool _hasChanged = false;
        private ModelState _modelState = new ModelState();
        private IValidator<VehicleModel> _validator;
        private IApplicationContext _applicationContext;
        public VehicleModelEditViewModel(IUnitOfWork unitOfWork, IValidator<VehicleModel> validator, IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _applicationContext = applicationContext;
            Id = Guid.Empty;
            FuelTypes.AddRange(_unitOfWork.FuelTypeRepository.Find().ToList());
            FuelTypes.Insert(0, new FuelType() { Id = Guid.Empty, Name = "" });
            _fuelType = FuelTypes[0];
        }
        public VehicleModelEditViewModel(VehicleModel vehicleModel, IUnitOfWork unitOfWork, IValidator<VehicleModel> validator, IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _applicationContext = applicationContext;
            Id = vehicleModel.Id;
            _name = vehicleModel.Name;
            _description = vehicleModel.Description;
            _fuelType = vehicleModel.DefaultFuelType;
            FuelTypes.AddRange(_unitOfWork.FuelTypeRepository.Find().ToList());
            FuelTypes.Insert(0, new FuelType() { Id = Guid.Empty, Name = "" });
           
            
        }
        public Guid Id { get; private set; }
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(this, nameof(Name));
                    Validate(VehicleModel);
                    HasChanged = true;
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(this, nameof(Description));
                    Validate(VehicleModel);
                    HasChanged = true;
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
                    Validate(VehicleModel);
                    HasChanged = true;
                }
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
        public VehicleModel VehicleModel
        {
            get
            {
                return new VehicleModel()
                {
                    Id = Id == Guid.Empty ? Guid.NewGuid() : Id,
                    Name = Name,
                    Description = Description,
                    DefaultFuelType = FuelType?.Id == Guid.Empty ? null : FuelType
                };
            }
        }
        public bool ValidateName(string newName)
        {
            var model = VehicleModel;
            model.Name = newName;
            var modelState = _validator.Validate(model);
            _modelState.Clear(nameof(Name));
            if (modelState.HasErrors)
            {
                _modelState.AddErrors(nameof(Name), modelState.GetErrors(nameof(Name)));
                return false;
            }
            return true;
        }
        public bool ValidteDescription(string newDesc)
        {
            var model = VehicleModel;
            model.Description = newDesc;
            var modelState = _validator.Validate(model);
            _modelState.Clear(nameof(Description));
            if (modelState.HasErrors)
            {
                _modelState.AddErrors(nameof(Description), modelState.GetErrors(nameof(Name)));
                return false;
            }
            return true;
        }
        private void Validate(VehicleModel vehicleModel)
        {
            _modelState.Clear();
            var modelState = _validator.Validate(vehicleModel);
            if (modelState.HasErrors)
            {
                _modelState.AddErrors(modelState);
            }
            else
            {
                if (Id == Guid.Empty) 
                {
                    if (_unitOfWork.VehicleModelRepository.Exists(e => e.Name.Equals(_name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        _modelState.AddError(nameof(Name), $"Duplicate Vehicle Model Name:\n Vehicle Model ${_name} already Exist");
                    }
                }
                else
                {
                    if (_unitOfWork.VehicleModelRepository.Exists(e => e.Id != Id && e.Name.Equals(_name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        _modelState.AddError(nameof(Name), $"Duplicate Vehicle Model Name:\n Vehicle Model ${_name} already Exist");
                    }
                }
            }
        }
        public bool SaveOrUpdte()
        {
            if (_hasChanged)
            {
                var vehicleModel = VehicleModel;
                Validate(vehicleModel);
                if (!_modelState.HasErrors)
                {
                    if (Id == Guid.Empty)
                    {
                        _unitOfWork.VehicleModelRepository.Add(new VehicleModel()
                        {
                            Name = vehicleModel.Name,
                            Description = vehicleModel.Description,
                            DefaultFuelType = vehicleModel.DefaultFuelType
                        });
                        _ = _unitOfWork.Complete();
                        HasChanged = false;
                    }
                    else
                    {
                        var old = _unitOfWork.VehicleModelRepository.Find(vehicleModel.Id);
                        old.Name = vehicleModel.Name;
                        old.DefaultFuelType = vehicleModel.DefaultFuelType;
                        old.Description = vehicleModel.Description;
                        _unitOfWork.Complete();
                        HasChanged = false;
                    }
                }
                return !_modelState.HasErrors;
            }
            return true;
        }
        public bool Close()
        {
            if (_hasChanged)
            {
                var result = _applicationContext.DisplayMessage("Confirm", "Do You Want To Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    return SaveOrUpdte();
                }
                else if(result == DialogResult.Cancel)
                {
                    return false;
                }
                else
                {
                    HasChanged = false;
                    return true;
                }
            }
            return true;
        }
        public List<FuelType> FuelTypes { get; private set; } = new List<FuelType>();
        #region IDataErrorInfo
        public string Error => _modelState.Error;
        public string this[string columnName] => _modelState[columnName];
        #endregion
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }

    }
}
