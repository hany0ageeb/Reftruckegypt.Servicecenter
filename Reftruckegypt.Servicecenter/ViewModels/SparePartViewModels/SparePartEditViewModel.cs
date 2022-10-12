using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartViewModels
{
    public class SparePartEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<SparePart> _validator; 
        private readonly ModelState _modelState = new ModelState();

        private string _code;
        private string _name;
        private bool _isEnabled;
        private Uom _uom;

        private bool _hasChanged = false;
        public SparePartEditViewModel(
            SparePart sparePart, 
            IUnitOfWork unitOfWork, 
            IApplicationContext applicationContext, 
            IValidator<SparePart> validator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));

            Uoms.AddRange(_unitOfWork.UomRepository.Find(predicate: x => x.IsEnabled, orderBy: q => q.OrderBy(x => x.Code)));
            if (sparePart != null)
            {
                Id = sparePart.Id;
                _code = sparePart.Code;
                _isEnabled = sparePart.IsEnabled;
                _name = sparePart.Name;
                _uom = sparePart.PrimaryUom;
                if (!Uoms.Contains(_uom))
                {
                    Uoms.Insert(0, _uom);
                }
                if(
                    _unitOfWork.SparePartPriceListLineRepository.Exists(e=>e.SparePartId == sparePart.Id) ||
                    _unitOfWork.SparePartsBillLineRepository.Exists(e=>e.SparePartId == sparePart.Id) ||
                    _unitOfWork.UomConversionRepository.Exists(e=>e.SparePartId == sparePart.Id)
                )
                {
                    IsUomEnabled = false;
                }
            }
            else
            {
                
                Id = Guid.Empty;
                _isEnabled = true;
                if(Uoms.Count > 0)
                    _uom = Uoms[0];
            }
        }
        public SparePartEditViewModel(
           IUnitOfWork unitOfWork,
           IApplicationContext applicationContext,
           IValidator<SparePart> validator)
            : this(null, unitOfWork, applicationContext, validator)
        {
            
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
        public bool IsUomEnabled { get; private set; } = true;
        public Guid Id { get; private set; }
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
        public Uom PrimaryUom
        {
            get => _uom;
            set
            {
                if (_uom != value)
                {
                    _uom = value;
                    OnPropertyChanged(this, nameof(PrimaryUom));
                    HasChanged = true;
                }
            }
        }
        public SparePart SparePart => new SparePart()
        {
            Id = Id,
            Code = _code,
            Name = _name,
            IsEnabled = _isEnabled,
            PrimaryUom = _uom
        };
        public void Validate()
        {
            _modelState.Clear();
            _modelState.AddErrors(_validator.Validate(SparePart));
            if (!_modelState.HasErrors)
            {
                if(Id == Guid.Empty)
                {
                    if (_unitOfWork.SparePartRepository.Exists(x=>x.Code.Equals(_code, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        _modelState.AddError(nameof(Code), $"Duplicate Spare Part Code.\nSpare Part Code: {_code} already exist.");
                    }
                }
                else
                {
                    if (_unitOfWork.SparePartRepository.Exists(x => x.Id != Id && x.Code.Equals(_code, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        _modelState.AddError(nameof(Code), $"Duplicate Spare Part Code.\nSpare Part Code: {_code} already exist.");
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
                    SparePart sparePart = SparePart;
                    if(sparePart.Id == Guid.Empty)
                    {
                        sparePart.Id = Guid.NewGuid();
                        _unitOfWork.SparePartRepository.Add(sparePart);
                    }
                    else
                    {
                        SparePart old = _unitOfWork.SparePartRepository.Find(key: sparePart.Id);
                        if (old != null)
                        {
                            old.Code = sparePart.Code;
                            old.Name = sparePart.Name;
                            old.IsEnabled = sparePart.IsEnabled;
                            if(IsUomEnabled)
                                old.PrimaryUom = sparePart.PrimaryUom;
                        }
                    }
                    _unitOfWork.Complete();
                    HasChanged = false;
                    return true;
                }
                else
                {
                    OnPropertyChanged(this, nameof(Code));
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
        public List<Uom> Uoms { get; private set; } = new List<Uom>();
        #region IDataErrorInfo
        public string this[string columnName] => _modelState[columnName];
        public string Error => _modelState.Error;
        #endregion IDataErrorInfo

    }
}
