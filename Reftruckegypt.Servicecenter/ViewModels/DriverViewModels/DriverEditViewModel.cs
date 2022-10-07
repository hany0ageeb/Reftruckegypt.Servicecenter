using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.DriverViewModels
{
    public class DriverEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<Driver> _validator;

        private string _name;
        private string _trafficDeptName;
        private string _licenseNumber;
        private DateTime _licenseEndDate = DateTime.Now;
        private bool _isEnabled;

        private bool _hasChanged = false;
        public DriverEditViewModel(IUnitOfWork unitOfWork,
                                   IApplicationContext applicationContext,
                                   IValidator<Driver> validator)
            : this(null, unitOfWork,applicationContext, validator)
        {

        }
        public DriverEditViewModel(Driver driver,
                                   IUnitOfWork unitOfWork,
                                   IApplicationContext applicationContext,
                                   IValidator<Driver> validator)
        {
            if (unitOfWork is null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _unitOfWork = unitOfWork;
            if (applicationContext is null)
            {
                throw new ArgumentNullException(nameof(applicationContext));
            }
            _applicationContext = applicationContext;
            if (validator is null)
            {
                throw new ArgumentNullException(nameof(validator));
            }
            _validator = validator;
            if(driver == null)
            {
                _isEnabled = true;
                _licenseEndDate = DateTime.Now;
                Id = Guid.Empty;
            }
            else
            {
                _isEnabled = driver.IsEnabled;
                _licenseEndDate = driver.LicenseEndDate;
                _licenseNumber = driver.LicenseNumber;
                _name = driver.Name;
                _trafficDeptName = driver.TrafficDepartmentName;
                Id = driver.Id;
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
            get => _name;
            set
            {
                if(_name != value)
                {
                    _name = value;
                    OnPropertyChanged(this, nameof(Name));
                    HasChanged = true;
                }
            }
        }
        public string LicenseNumber
        {
            get => _licenseNumber;
            set
            {
                if (_licenseNumber != value)
                {
                    _licenseNumber = value;
                    OnPropertyChanged(this, nameof(LicenseNumber));
                    HasChanged = true;
                }
            }
        }
        public string TrafficDepartmentName
        {
            get => _trafficDeptName;
            set
            {
                if (_trafficDeptName != value)
                {
                    _trafficDeptName = value;
                    OnPropertyChanged(this, nameof(TrafficDepartmentName));
                    HasChanged = true;
                }
            }
        }
        public DateTime LicenseEndDate
        {
            get => _licenseEndDate;
            set
            {
                if (_licenseEndDate != value)
                {
                    _licenseEndDate = value;
                    OnPropertyChanged(this, nameof(LicenseEndDate));
                    HasChanged = true;
                }
            }
        }
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if(_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged(this, nameof(IsEnabled));
                    HasChanged = true;
                }
            }
        }
        public Driver Driver => new Driver()
        {
            Name = _name,
            Id = Id,
            TrafficDepartmentName = _trafficDeptName,
            LicenseEndDate = _licenseEndDate,
            LicenseNumber = _licenseNumber,
            IsEnabled = _isEnabled
        };
        private void Validate()
        {
            _modelState.Clear();
            _modelState.AddErrors(_validator.Validate(Driver));
            if (!_modelState.HasErrors)
            {
                if (Id == Guid.Empty)
                {
                    if (_unitOfWork.DriverRepository.Exists(x=>x.Name.Equals(_name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        _modelState.AddError(nameof(Name), $"Duplicate Driver Name.\n Driver: {_name} alredy exist!");
                    }
                }
                else
                {
                    if (_unitOfWork.DriverRepository.Exists(x => x.Id != Id && x.Name.Equals(_name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        _modelState.AddError(nameof(Name), $"Duplicate Driver Name.\n Driver: {_name} alredy exist!");
                    }
                }
            }
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                Validate();
                OnPropertyChanged(this, nameof(Name));
                if (!_modelState.HasErrors)
                {
                    if(Id == Guid.Empty)
                    {
                        Driver driver = Driver;
                        driver.Id = Guid.NewGuid();
                        _unitOfWork.DriverRepository.Add(driver);
                    }
                    else
                    {
                        Driver oldDriver = _unitOfWork.DriverRepository.Find(key: Id);
                        if (oldDriver != null)
                        {
                            oldDriver.IsEnabled = _isEnabled;
                            oldDriver.Name = _name;
                            oldDriver.LicenseEndDate = _licenseEndDate;
                            oldDriver.LicenseNumber = _licenseNumber;
                            oldDriver.TrafficDepartmentName = _trafficDeptName;
                        }
                    }
                    _unitOfWork.Complete();
                    HasChanged = false;
                    return true;
                }
            }
            return true;
        }
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result = _applicationContext.DisplayMessage("Confirm Save", "Do You Want To Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
        private readonly ModelState _modelState = new ModelState();
        public string this[string columnName] => _modelState[columnName];
        public string Error => _modelState.Error;
    }
}
