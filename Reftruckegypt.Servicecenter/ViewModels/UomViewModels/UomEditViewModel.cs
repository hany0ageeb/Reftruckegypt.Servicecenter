using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.UomViewModels
{
    public class UomEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<Uom> _validator;
        private string _code;
        private string _name;
        private bool _isEnabled;

        private bool _hasChanged = false;
        public UomEditViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext, IValidator<Uom> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _applicationContext = applicationContext;

            Id = Guid.Empty;
            _isEnabled = true;
            _code = "";
            _name = "";
        }
        public UomEditViewModel(Uom uom, IUnitOfWork unitOfWork, IApplicationContext applicationContext, IValidator<Uom> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _applicationContext = applicationContext;

            _name = uom.Name;
            _code = uom.Code;
            _isEnabled = uom.IsEnabled;
            Id = uom.Id;
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
                    OnPropertyChanged(this, nameof(HasChanged));
                }
            }
        }
        public string Code
        {
            get => _code;
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged(this, nameof(Code));
                    HasChanged = true;
                    Validate();
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
                    HasChanged = true;
                    Validate();
                }
            }
        }
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged(this, nameof(IsEnabled));
                    HasChanged = true;
                }
            }
        }
        public Uom Uom => new Uom()
        {
            Id = Id == Guid.Empty ? Guid.NewGuid() : Id,
            Code = _code,
            Name = _name,
            IsEnabled = _isEnabled
        };
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                Validate();
                if (!_modelState.HasErrors)
                {
                    Uom uom = Uom;
                    if(Id == Guid.Empty)
                    {
                        _unitOfWork.UomRepository.Add(uom);
                    }
                    else
                    {
                        Uom oldUom = _unitOfWork.UomRepository.Find(key: uom.Id);
                        oldUom.IsEnabled = uom.IsEnabled;
                        oldUom.Name = uom.Name;
                        oldUom.Code = uom.Code;
                    }
                    _unitOfWork.Complete();
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
        private void Validate()
        {
            _modelState.Clear();
            _modelState.AddErrors(_validator.Validate(Uom));
            if (!_modelState.HasErrors)
            {
                if(Id == Guid.Empty)
                {
                    if (_unitOfWork.UomRepository.Exists(x => x.Code.Equals(_code, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        _modelState.AddError(nameof(Code), $"Duplicate Uom Code.\n Uom Code: {_code} already exist");
                    }
                }
                else
                {
                    if (_unitOfWork.UomRepository.Exists(x => x.Id != Id && x.Code.Equals(_code, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        _modelState.AddError(nameof(Code), $"Duplicate Uom Code.\n Uom Code: {_code} already exist");
                    }
                }
            }
        }
        private ModelState _modelState = new ModelState();
        #region IDataErrorInfo
        public string this[string columnName] => _modelState[columnName];
        public string Error => _modelState.Error;
        #endregion IDataErrorInfo
    }
}
