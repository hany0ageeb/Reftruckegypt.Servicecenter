using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.InternalMemoViewModels
{
    public class InternalMemoEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<InternalMemo> _validator;
        private InternalMemo _internalMemeo;

        private bool _hasChanged = false;

        public InternalMemoEditViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<InternalMemo> validator)
            : this(null, unitOfWork, applicationContext, validator)
        {

        }
        public InternalMemoEditViewModel(
            InternalMemo internalMemo,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<InternalMemo> validator
            )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));

            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q=>q.OrderBy(x=>x.InternalCode)));

            if (internalMemo is null)
            {
                _internalMemeo = new InternalMemo()
                {
                    Id = Guid.Empty,
                    MemoDate = DateTime.Now
                };
                if (Vehicles.Count > 0)
                    _internalMemeo.Vehicle = Vehicles[0];
            }
            else
            {
                _internalMemeo = new InternalMemo()
                {
                    Id = internalMemo.Id,
                    MemoDate = internalMemo.MemoDate,
                    Vehicle = internalMemo.Vehicle,
                    Header = internalMemo.Header,
                    Content = internalMemo.Content
                };
                if (!Vehicles.Contains(internalMemo.Vehicle))
                {
                    Vehicles.Add(internalMemo.Vehicle);
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
        public string Number
        {
            get => _internalMemeo.Number.ToString();
        }
        public string Header
        {
            get => _internalMemeo.Header;
            set
            {
                if(_internalMemeo.Header != value)
                {
                    _internalMemeo.Header = value;
                    OnPropertyChanged(this, nameof(Header));
                    HasChanged = true;
                }
                
            }
        }
        public string Content
        {
            get => _internalMemeo.Content;
            set
            {
                if (_internalMemeo.Content != value)
                {
                    _internalMemeo.Content = value;
                    OnPropertyChanged(this, nameof(Content));
                    HasChanged = true;
                }
            }
        }
        public DateTime MemoDate
        {
            get => _internalMemeo.MemoDate; 
            set
            {
                if (_internalMemeo.MemoDate != value)
                {
                    _internalMemeo.MemoDate = value;
                    OnPropertyChanged(this, nameof(MemoDate));
                    HasChanged = true;
                }
            }
        }
        public Vehicle Vehicle
        {
            get => _internalMemeo.Vehicle; 
            set
            {
                if (_internalMemeo.Vehicle != value)
                {
                    _internalMemeo.Vehicle = value;
                    OnPropertyChanged(this, nameof(Vehicle));
                    HasChanged = true;
                }
            }
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                ModelState modelState = Validate();
                if (!modelState.HasErrors)
                {
                    if(_internalMemeo.Id == Guid.Empty)
                    {
                        _unitOfWork.InternalMemoRepository.Add(new InternalMemo()
                        {
                            Header = _internalMemeo.Header,
                            Content = _internalMemeo.Content,
                            MemoDate = _internalMemeo.MemoDate,
                            Period = _internalMemeo.Period,
                            Vehicle = _internalMemeo.Vehicle
                        });
                        _unitOfWork.Complete();
                        OnPropertyChanged(this, nameof(Number));
                        HasChanged = false;
                        return true;
                    }
                    else
                    {
                        InternalMemo old = _unitOfWork.InternalMemoRepository.Find(key: _internalMemeo.Id);
                        if (old != null)
                        {
                            old.Header = _internalMemeo.Header;
                            old.Content = _internalMemeo.Content;
                            old.MemoDate = _internalMemeo.MemoDate;
                            old.Period = _internalMemeo.Period;
                            old.Vehicle = _internalMemeo.Vehicle;
                            _unitOfWork.Complete();
                        }
                        HasChanged = false;
                        return true;
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
                DialogResult result =
                    _applicationContext.DisplayMessage("Confirm Save", "Do You Want To Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
        public ModelState Validate()
        {
            ModelState modelState = new ModelState();
            _internalMemeo.Period = _unitOfWork.PeriodRepository.FindOpenPeriod(_internalMemeo.MemoDate);
            modelState.AddErrors(_validator.Validate(_internalMemeo));
            return modelState;
        }
    }
}
