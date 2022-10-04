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

namespace Reftruckegypt.Servicecenter.ViewModels.ExternalAutoRepairShopViewModels
{
    public class ExternalAutoRepairShopEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private ModelState _modelState = new ModelState();
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<ExternalAutoRepairShop> _validator;
        private string _name = "";
        private string _address = "";
        private string _phone = "";
        private bool _isEnabled = true;
        private bool _hasChanged = false;
        public ExternalAutoRepairShopEditViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext, IValidator<ExternalAutoRepairShop> validator)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _validator = validator;
            Id = Guid.Empty;
        }
        public ExternalAutoRepairShopEditViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext, IValidator<ExternalAutoRepairShop> validator, ExternalAutoRepairShop shop)
        {
            _applicationContext = applicationContext;
            _unitOfWork = unitOfWork;
            _validator = validator;
            Id = shop.Id;
            _name = shop.Name;
            _address = shop.Address;
            _phone = shop.Phone;
            _isEnabled = shop.IsEnabled;
        }
        public ExternalAutoRepairShop ExternalAutoRepairShop => new ExternalAutoRepairShop()
        {
            Id = Id == Guid.Empty ? Guid.NewGuid() : Id,
            Name = Name,
            Address = Address,
            Phone = Phone,
            IsEnabled = IsEnabled
        };

        public Guid Id { get; private set; }
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    HasChanged = true;
                    OnPropertyChanged(this, nameof(IsEnabled));
                }
            }
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
                    Validate();
                    HasChanged = true;
                }
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(this, nameof(Address));
                    Validate();
                    HasChanged = true;
                }
            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(this, nameof(Phone));
                    Validate();
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
        private void Validate()
        {
            _modelState.Clear();
            _modelState.AddErrors(_validator.Validate(ExternalAutoRepairShop));
            if (!_modelState.HasErrors)
            {
                if(Id == Guid.Empty)
                {
                    if (_unitOfWork.ExternalAutoRepairShopRepository.Exists(e => e.Name == _name))
                    {
                        _modelState.AddError(nameof(Name), $"Duplicate External Shop Name.\n${_name} already exist");
                    }
                }
                else
                {
                    if (_unitOfWork.ExternalAutoRepairShopRepository.Exists(e => e.Name == _name && e.Id != Id))
                    {
                        _modelState.AddError(nameof(Name), $"Duplicate External Shop Name.\n${_name} already exist");
                    }
                }
            }
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                Validate();
                if (!_modelState.HasErrors)
                {
                    if(Id == Guid.Empty)
                    {
                        _unitOfWork.ExternalAutoRepairShopRepository.Add(new ExternalAutoRepairShop()
                        {
                            Name = _name,
                            Address = _address,
                            Phone = _phone,
                            IsEnabled = _isEnabled
                        });
                        _ = _unitOfWork.Complete();
                        HasChanged = false;
                    }
                    else
                    {
                        var old = _unitOfWork.ExternalAutoRepairShopRepository.Find(Id);
                        if (old != null)
                        {
                            old.Name = _name;
                            old.Address = _address;
                            old.Phone = _phone;
                            old.IsEnabled = _isEnabled;
                            _ = _unitOfWork.Complete();
                            HasChanged = false;
                        }
                        
                    }
                    return true;
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
                var result = _applicationContext.DisplayMessage("Question", "Do You Want To Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(result == DialogResult.No)
                {
                    HasChanged = false;
                    return true;
                }
                else if(result == DialogResult.Yes)
                {
                    return SaveOrUpdate();
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        #region IDataErrorInfo
        public string this[string columnName] => _modelState[columnName];
        public string Error => _modelState.Error;
        #endregion IDataErrorInfo
    }
}
