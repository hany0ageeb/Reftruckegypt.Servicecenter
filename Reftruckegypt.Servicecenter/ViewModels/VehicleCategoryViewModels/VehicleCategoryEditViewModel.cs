using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleCategoryViewModels
{
    public class VehicleCategoryEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private string _name;
        private string _description;
        private bool _isFuelCardRequired;
        private bool _isChassisNumberRequired;
        private bool _hasChanged = false;
        private readonly IValidator<VehicleCategory> _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ModelState _modelState = new ModelState();
        private readonly Common.IApplicationContext _applicationContext;
        public VehicleCategoryEditViewModel(IValidator<VehicleCategory> validator, IUnitOfWork unitOfWork, Common.IApplicationContext applicationContext)
        {
            _name = "";
            _description = "";
            _isFuelCardRequired = true;
            _isChassisNumberRequired = true;
            Id = Guid.Empty;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
        }
        public VehicleCategoryEditViewModel(VehicleCategory vehicleCategory, IValidator<VehicleCategory> validator, IUnitOfWork unitOfWork, Common.IApplicationContext applicationContext)
        {
            _name = vehicleCategory.Name;
            _description = vehicleCategory.Description;
            _isChassisNumberRequired = vehicleCategory.IsChassisNumberRequired;
            _isFuelCardRequired = vehicleCategory.IsFuelCardRequired;
            Id = vehicleCategory.Id;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
        }
        public ModelState ModelState
        {
            get
            {
                var temp = Validate();
                _modelState.Clear();
                _modelState.AddErrors(temp);
                return _modelState;
            }
        }
        public VehicleCategory VehicleCategory => new VehicleCategory()
        {
            Id = Id == Guid.Empty? Guid.NewGuid() : Id,
            Name = Name,
            Description = Description,
            IsChassisNumberRequired = IsChassisNumberRequired,
            IsFuelCardRequired = IsFuelCardRequired
        };

       
        public string IsNameValid(string name)
        {
            if (_hasChanged)
            {
                var cat = VehicleCategory;
                cat.Name = name;
                var modelState = _validator.Validate(cat);
                if (modelState.HasErrors)
                {
                    return modelState.GetError(nameof(Name));
                }
                return string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }
        public string IsDescriptionValid(string description)
        {
            if (_hasChanged)
            {
                var cat = VehicleCategory;
                cat.Description = description;
                var modelState = _validator.Validate(cat);
                if (modelState.HasErrors)
                {
                    return modelState.GetError(nameof(Description));
                }
                return string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }
        private ModelState Validate()
        {
            if (_hasChanged)
            {
                var modelState = _validator.Validate(VehicleCategory);
                if (!modelState.HasErrors)
                {
                    if (Id == Guid.Empty)
                    {
                        if (_unitOfWork.VehicleCategoryRepository.Exists(e => e.Name.Equals(Name, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            modelState.AddError(nameof(Name), $"Duplicate Vehicle Category Name: ${Name} already Exist.");
                        }
                    }
                    else
                    {
                        if (_unitOfWork.VehicleCategoryRepository.Exists(e => e.Name.Equals(Name, StringComparison.InvariantCultureIgnoreCase) && e.Id != Id))
                        {
                            modelState.AddError(nameof(Name), $"Duplicate Vehicle Category Name: ${Name} already Exist.");
                        }
                    }
                }
                return modelState;
            }
            return new ModelState();
        }
        public bool Close()
        {
            if (_hasChanged)
            {
                var result = _applicationContext.DisplayMessage("Confirm", "Do You Want To Save The Changes?", Common.MessageBoxButtons.YesNoCancel, Common.MessageBoxIcon.Question);
                if(result == Common.DialogResult.Yes)
                {
                    var modelState = SaveOrUpdate();
                    return !modelState.HasErrors;
                }
                else if(result == Common.DialogResult.Cancel)
                {
                    return false;
                }
                else
                {
                    _hasChanged = false;
                    return true;
                }
            }
            return true;
        }
        public ModelState SaveOrUpdate()
        {
            ModelState modelState = Validate();
            if (!modelState.HasErrors)
            {
                if (Id == Guid.Empty)
                {
                    _unitOfWork.VehicleCategoryRepository.Add(new VehicleCategory()
                    {
                        Name = Name,
                        Description = Description,
                        IsChassisNumberRequired = IsChassisNumberRequired,
                        IsFuelCardRequired = IsFuelCardRequired
                    });
                    _unitOfWork.Complete();
                    _hasChanged = false;
                    IsSaveEnabled = false;
                }
                else
                {
                    var old = _unitOfWork.VehicleCategoryRepository.Find(Id);
                    if (old != null)
                    {
                        old.Name = Name;
                        old.Description = Description;
                        old.IsChassisNumberRequired = IsChassisNumberRequired;
                        old.IsFuelCardRequired = IsFuelCardRequired;
                        _unitOfWork.Complete();
                        _hasChanged = false;
                        IsSaveEnabled = false;
                    }
                }
            }
            return modelState;
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
                    _hasChanged = true;
                    OnPropertyChanged(this, nameof(IsSaveEnabled));
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
                    _hasChanged = true;
                    OnPropertyChanged(this, nameof(IsSaveEnabled));
                }
            }
        }
        public bool IsFuelCardRequired
        {
            get => _isFuelCardRequired;
            set
            {
                if (_isFuelCardRequired != value)
                {
                    _isFuelCardRequired = value;
                    OnPropertyChanged(this, nameof(IsFuelCardRequired));
                    _hasChanged = true;
                    OnPropertyChanged(this, nameof(IsSaveEnabled));
                }
            }
        }
        public bool IsChassisNumberRequired
        {
            get => _isChassisNumberRequired;
            set
            {
                if (_isChassisNumberRequired != value)
                {
                    _isChassisNumberRequired = value;
                    OnPropertyChanged(this, nameof(_isChassisNumberRequired));
                    _hasChanged = true;
                    OnPropertyChanged(this, nameof(IsSaveEnabled));
                }
            }
        }
        public bool IsSaveEnabled
        {
            get => _hasChanged;
            set
            {
                if (_hasChanged != value)
                {
                    _hasChanged = value;
                    OnPropertyChanged(this, nameof(IsSaveEnabled));
                }
            }
        }

        public string Error => ModelState.Error;

        public string this[string columnName] => ModelState[columnName];
    }
}
