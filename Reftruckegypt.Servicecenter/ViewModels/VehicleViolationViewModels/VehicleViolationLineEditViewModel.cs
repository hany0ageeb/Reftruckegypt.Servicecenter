using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels
{
    public class VehicleViolationLineEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private Vehicle _vehicle;
        private int _count;
        private Period _period;
        private DateTime _violaionDate;
        private ViolationType _violationType;
        private string _notes;
        public VehicleViolationLineEditViewModel()
        {
            Id = Guid.Empty;
            _notes = "";
        }
        public VehicleViolationLineEditViewModel(VehicleViolation vehicleViolation)
        {
            Id = vehicleViolation.Id;
            _count = vehicleViolation.Count;
            _vehicle = vehicleViolation.Vehicle;
            _period = vehicleViolation.Period;
            _violaionDate = vehicleViolation.ViolationDate;
            _violationType = vehicleViolation.ViolationType;
            _notes = vehicleViolation.Notes;
        }
        public IValidator<VehicleViolation> Validator { get; set; } = new VehicleViolationValidator();
        public Guid Id { get; set; }
        public Vehicle Vehicle
        {
            get => _vehicle;
            set
            {
                if (_vehicle != value)
                {
                    _vehicle = value;
                    
                    OnPropertyChanged(this, nameof(Vehicle));
                }
            }
        }
        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged(this, nameof(Count));
                }
            }
        }
        public Period Period
        {
            get => _period;
            set
            {
                if (_period != value)
                {
                    _period = value;
                    
                    OnPropertyChanged(this, nameof(Period));
                }
            }
        }
        public DateTime ViolationDate
        {
            get => _violaionDate;
            set
            {
                if (_violaionDate != value)
                {
                    _violaionDate = value;
                    OnPropertyChanged(this, nameof(ViolationDate));
                }
            }
        }
        public ViolationType ViolationType
        {
            get => _violationType;
            set
            {
                if (_violationType != value)
                {
                    _violationType = value;
                    OnPropertyChanged(this, nameof(ViolationType));
                }
            }
        }
        public string Notes
        {
            get => _notes;
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    OnPropertyChanged(this, nameof(Notes));
                }
            }
        }
        public VehicleViolation VehicleViolation => new VehicleViolation()
        {
            Id = Id,
            Notes = _notes,
            Period = _period,
            Count = _count,
            Vehicle = _vehicle,
            ViolationDate = _violaionDate,
            ViolationType = _violationType
        };
        public ModelState Validate(bool notify = false)
        {
            

            ModelState modelState = Validator.Validate(VehicleViolation);
            if (notify)
                OnPropertyChanged(this, nameof(Vehicle));
            return modelState;
        }
        #region IDataErrorInfo
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
        #endregion IDataErrorInfo
    }
}
