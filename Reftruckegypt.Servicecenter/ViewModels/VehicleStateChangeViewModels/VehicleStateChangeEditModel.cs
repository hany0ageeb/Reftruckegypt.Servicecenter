using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleStateChangeViewModels
{
    public class VehicleStateChangeEditModel : ViewModelBase, IDataErrorInfo
    {
        private Vehicle _vehicle;
        private DateTime _fromDate;
        private DateTime? _toDate;
        private string _notes;

        public VehicleStateChangeEditModel() : this(null)
        {

        }
        public VehicleStateChangeEditModel(VehicleStateChange vehicleStateChange)
        {
            if(vehicleStateChange is null)
            {
                _fromDate = DateTime.Now;
                _notes = "";
                Id = Guid.Empty;
            }
            else
            {
                Id = vehicleStateChange.Id;
                _vehicle = vehicleStateChange.Vehicle;
                _fromDate = vehicleStateChange.FromDate;
                _toDate = vehicleStateChange.ToDate;
                _notes = vehicleStateChange.Notes;
            }
        }
        public IValidator<VehicleStateChange> Validator { get; set; }
        public Guid Id { get; private set; }
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
        public DateTime FromDate
        {
            get => _fromDate;
            set
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    OnPropertyChanged(this, nameof(FromDate));
                }
            }
        }
        public DateTime? ToDate
        {
            get => _toDate;
            set
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    OnPropertyChanged(this, nameof(ToDate));
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
        public VehicleStateChange VehicleStateChange => new VehicleStateChange()
        {
            Id = Id,
            Vehicle = _vehicle,
            Notes = _notes,
            FromDate = _fromDate,
            ToDate = _toDate
        };
        public ModelState Validate()
        {
            ModelState modelState = new ModelState();
            if (Validator != null)
                modelState.AddErrors(Validator.Validate(VehicleStateChange));
            return modelState;
        }
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
    }
}
