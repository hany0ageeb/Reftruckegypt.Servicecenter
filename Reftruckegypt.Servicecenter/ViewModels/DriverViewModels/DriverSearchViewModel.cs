using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.DriverViewModels
{
    public class DriverSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private IApplicationContext _applicationContext;
        private readonly IValidator<Driver> _validator;
        private string _name = "";
        private string _licenseNumber = "";
        private DateTime? _fromDate = null;
        private DateTime? _toDate = null;
        private bool _isDisposed = false;
        private int _selectedIndex = -1;
        private bool _isEditEnabled = false;
        private bool _isDeleteEnabled = false;

        public DriverSearchViewModel(
            IUnitOfWork unitOfWork, 
            IApplicationContext applicationContext,
            IValidator<Driver> validator)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _validator = validator;
        }
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(this, nameof(Name));
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
                }
            }
        }
        public DateTime? EndDateFrom
        {
            get => _fromDate;
            set
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    OnPropertyChanged(this, nameof(EndDateFrom));
                }
            }
        }
        public DateTime? EndDateTo
        {
            get => _toDate;
            set
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    OnPropertyChanged(this, nameof(EndDateTo));
                }
            }
        }
        public int Selectedindex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    if(_selectedIndex >= 0 && _selectedIndex < Drivers.Count)
                    {
                        IsEditEnabled = true;
                        IsDeleteEnabled = true;
                    }
                    else
                    {
                        IsEditEnabled = false;
                        IsDeleteEnabled = false;
                    }
                }
            }
        }
        public void Search()
        {
            Drivers.Clear();
            IEnumerable<Driver> drivers = 
                _unitOfWork.DriverRepository.Find(driverName: _name,
                                                  licenseNumber: _licenseNumber,
                                                  licenseEndDateFrom: _fromDate,
                                                  licenseEndDateTo: _toDate,
                                                  orderBy: q => q.OrderBy(x => x.Name));
            foreach(Driver driver in drivers)
            {
                Drivers.Add(driver);
            }
        }
        public void Create()
        {
            DriverEditViewModel driverEditViewModel = new DriverEditViewModel(_unitOfWork, _applicationContext, _validator);
            _applicationContext.DisplayDriverEditView(driverEditViewModel);
            Search();
        }
        public void Delete()
        {
            if (!_isDeleteEnabled || _selectedIndex < 0 || _selectedIndex >= Drivers.Count)
                return;
            DialogResult result = _applicationContext.DisplayMessage("Confirm Delete", $"Are You Sure You Want To Delete Driver: {Drivers[_selectedIndex].Name}?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Driver oldDriver = _unitOfWork.DriverRepository.Find(key: Drivers[_selectedIndex].Id);
                if (oldDriver != null)
                {
                    _unitOfWork.DriverRepository.Remove(oldDriver);
                    _unitOfWork.Complete();
                    Search();
                }
            }
        }
        public void Edit()
        {
            if (!_isEditEnabled || _selectedIndex < 0 || _selectedIndex >= Drivers.Count)
                return;
            DriverEditViewModel driverEditViewModel = new DriverEditViewModel(_unitOfWork.DriverRepository.Find(key: Drivers[_selectedIndex].Id), _unitOfWork, _applicationContext, _validator);
            _applicationContext.DisplayDriverEditView(driverEditViewModel);
            Search();
        }
        public bool IsEditEnabled
        {
            get => _isEditEnabled;
            private set
            {
                if (_isEditEnabled = value)
                {
                    _isEditEnabled = value;
                    OnPropertyChanged(this, nameof(IsEditEnabled));
                }
           
            }
        }
        public bool IsDeleteEnabled
        {
            get => _isDeleteEnabled;
            private set
            {
                if (_isDeleteEnabled = value)
                {
                    _isDeleteEnabled = value;
                    OnPropertyChanged(this, nameof(IsDeleteEnabled));
                }
            }
        }
        public BindingList<Driver> Drivers { get; private set; } = new BindingList<Driver>();
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }
    }
}
