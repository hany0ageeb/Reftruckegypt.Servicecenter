﻿using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels
{
    public class VehicleViolationEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;

        private ModelState _modelState = new ModelState();

        private DateTime _violationDate;
        private bool _hasChanged = false;

        public VehicleViolationEditViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            ViolationDate = DateTime.Now;
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(orderBy: q => q.OrderBy(x => x.InternalCode)));
            ViolationTypes.AddRange(_unitOfWork.ViolationTypeRepository.Find(predicate: x => x.IsEnabled, orderBy: q => q.OrderBy(x => x.Name)));
            HasChanged = false;
        }
        public VehicleViolationEditViewModel(VehicleViolation line, IUnitOfWork unitOfWork, IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            ViolationDate = line.ViolationDate;
            Lines.Add(new VehicleViolationLineEditViewModel(line));
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(orderBy: q => q.OrderBy(x => x.InternalCode)));
            ViolationTypes.AddRange(_unitOfWork.ViolationTypeRepository.Find(predicate: x => x.IsEnabled, orderBy: q => q.OrderBy(x => x.Name)));
            if (!ViolationTypes.Contains(line.ViolationType))
            {
                ViolationTypes.Add(line.ViolationType);
            }
            HasChanged = false;
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
        public DateTime ViolationDate
        {
            get => _violationDate;
            set
            {
                if (_violationDate != value)
                {
                    _violationDate = value;
                    ValidateDate();
                    HasChanged = true;
                    OnPropertyChanged(this, nameof(ViolationDate));
                }
            }
        }
        private void ValidateDate()
        {
            _modelState.RemoveErrors(nameof(ViolationDate));
            Period period = _unitOfWork.PeriodRepository.FindOpenPeriod(_violationDate);
            if(period == null)
            {
                _modelState.AddError(nameof(ViolationDate), $"No Open Period For Date: {_violationDate} Pleas Enter another Date Or create/open period for that date.");
            }
            foreach (var line in Lines)
            {
                line.Period = period;
                line.ViolationDate = _violationDate;
            }
        }
        private ModelState Validate()
        {
            _modelState.Clear();
            ValidateDate();
            if (!_modelState.HasErrors)
            {
                foreach(var line in Lines)
                {
                    ModelState modelState = line.Validate(true);
                    if (modelState.HasErrors)
                        return modelState;
                }
            }
            return _modelState;
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                if (Validate().HasErrors)
                {
                    return false;
                }
                IEnumerable<VehicleViolation> lines = Lines.Select(l => l.VehicleViolation);
                foreach(var line in lines)
                {
                    if(line.Id == Guid.Empty)
                    {
                        line.Id = Guid.NewGuid();
                        _unitOfWork.VehicleViolationRepository.Add(line);
                    }
                    else
                    {
                        VehicleViolation vehicleViolation = _unitOfWork.VehicleViolationRepository.Find(key: line.Id);
                        if (vehicleViolation != null)
                        {
                            vehicleViolation.Count = line.Count;
                            vehicleViolation.Notes = line.Notes;
                            vehicleViolation.Period = line.Period;
                            vehicleViolation.Vehicle = line.Vehicle;
                            vehicleViolation.ViolationDate = line.ViolationDate;
                            vehicleViolation.ViolationType = line.ViolationType;
                        }
                    }
                }
                _unitOfWork.Complete();
                HasChanged = false;
                return true;
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
        public BindingList<VehicleViolationLineEditViewModel> Lines { get; private set; } = new BindingList<VehicleViolationLineEditViewModel>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public List<ViolationType> ViolationTypes { get; private set; } = new List<ViolationType>();
        #region IDataErrorInfo
        public string Error => _modelState.Error;
        public string this[string columnName] => _modelState[columnName];
        #endregion IDataErrorInfo
    }
}
