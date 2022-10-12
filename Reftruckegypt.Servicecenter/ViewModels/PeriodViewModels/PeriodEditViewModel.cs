using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.PeriodViewModels
{
    public class PeriodEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<Period> _validator;
        private readonly ModelState _modelState = new ModelState();

        private bool _hasChanged = false;

        private string _name;
        private DateTime _fromDate;
        private DateTime _toDate;
        private string _state;

        public Guid Id { get; private set; }
        public PeriodEditViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext, IValidator<Period> validator)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _validator = validator;

            _name = "";
            _state = Models.PeriodStates.OpenState;
            Id = Guid.Empty;
            _fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime oneMonthLater = _fromDate.AddMonths(1);
            _toDate = new DateTime(oneMonthLater.Year, oneMonthLater.Month, oneMonthLater.Day, 23, 59, 59);
        }
        public PeriodEditViewModel(Period period, IUnitOfWork unitOfWork, IApplicationContext applicationContext, IValidator<Period> validator)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _validator = validator;

            Id = period.Id;
            _name = period.Name;
            _fromDate = period.FromDate;
            _toDate = period.ToDate;
            _state = period.State;

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
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    Validate();
                    OnPropertyChanged(this, nameof(Name));
                    HasChanged = true;
                }
            }
        }
        public DateTime FromDate
        {
            get => _fromDate;
            set
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    Validate();
                    OnPropertyChanged(this, nameof(FromDate));
                    HasChanged = true;
                }
            }
        }
        public DateTime ToDate
        {
            get => _toDate;
            set
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    Validate();
                    OnPropertyChanged(this, nameof(ToDate));
                    HasChanged = true;
                }
            }
        }
        public string State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;
                    Validate();
                    OnPropertyChanged(this, nameof(State));
                    HasChanged = true;
                }
            }
        }
        public Period Period => new Period()
        {
            Id = Id == Guid.Empty ? Guid.NewGuid() : Id,
            Name = _name,
            FromDate = _fromDate,
            ToDate = _toDate,
            State = _state
        };
        public List<string> PeriodStates { get; private set; } = new List<string>(Models.PeriodStates.AllStates);
        #region IDataErrorInfo
        public string Error => _modelState.Error;
        public string this[string columnName] => _modelState[columnName];
        #endregion IDataErrorInfo
        private void Validate()
        {
            _modelState.Clear();
            Period period = Period;
            var modelState = _validator.Validate(period);
            if (!modelState.HasErrors)
            {
                if (Id == Guid.Empty) 
                {
                    if (_unitOfWork.PeriodRepository.Exists(p => p.Name.Equals(_name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        modelState.AddError(nameof(period.Name), $"Duplicate Period Name.\nPeriod Name {period.Name} already exists");
                    }
                }
                else
                {
                    if (_unitOfWork.PeriodRepository.Exists(p => p.Id != Id && p.Name.Equals(_name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        modelState.AddError(nameof(period.Name), $"Duplicate Period Name.\nPeriod Name {period.Name} already exists");
                    }
                }
            }
            if (!modelState.HasErrors)
            {
                if(Id == Guid.Empty)
                {
                    IList<Period> overlappingPeriods = 
                        _unitOfWork
                        .PeriodRepository
                        .Find(x => (x.FromDate >= _fromDate && x.FromDate <= _toDate) || (x.ToDate >= _fromDate && x.ToDate <= _toDate)||(x.FromDate <= _fromDate && x.ToDate >= _toDate)||(x.FromDate <= _fromDate && x.ToDate >= _toDate)).ToList();
                    if(overlappingPeriods.Count > 0)
                    {
                        modelState.AddError(nameof(period.FromDate), $"Overlapping Periods.\nPeriod {period.Name} overlaps with period {overlappingPeriods[0].Name}");
                    }
                }
                else
                {
                    IList<Period> overlappingPeriods = 
                        _unitOfWork
                        .PeriodRepository
                        .Find(x => x.Id != Id && ((x.FromDate >= _fromDate && x.FromDate <= _toDate) || (x.ToDate >= _fromDate && x.ToDate <= _toDate) || (x.FromDate <= _fromDate && x.ToDate >= _toDate) || (x.FromDate <= _fromDate && x.ToDate >= _toDate))).ToList();
                    if (overlappingPeriods.Count > 0)
                    {
                        modelState.AddError(nameof(period.FromDate), $"Overlapping Periods.\nPeriod {period.Name} overlaps with period {overlappingPeriods[0].Name}");
                    }
                }
            }
            _modelState.AddErrors(modelState);
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                Validate();
                if (_modelState.HasErrors)
                {
                    
                    return false;
                }
                else
                {
                    if(Id == Guid.Empty)
                    {
                        _unitOfWork.PeriodRepository.Add(Period);
                        _unitOfWork.Complete();
                        HasChanged = false;
                        return true;
                    }
                    else
                    {
                        Period old = _unitOfWork.PeriodRepository.Find(Id);
                        if (old != null)
                        {
                            old.Name = _name;
                            old.FromDate = _fromDate;
                            old.ToDate = _toDate;
                            old.State = _state;
                            _unitOfWork.Complete();
                        }
                        HasChanged = false;
                        return true;
                    }
                }
            }
            return true;
        }
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result = _applicationContext.DisplayMessage("Confirm Save", $"Do You Want To Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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

    }
}
