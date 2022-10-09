using System;
using System.ComponentModel;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleViewModels
{
    public class VehicleLicenseEditViewmodel : ViewModelBase, IDataErrorInfo
    {
        private readonly VehicleLicense _vehicleLicense;
        public VehicleLicenseEditViewmodel()
        {
            _vehicleLicense = new VehicleLicense();
            _vehicleLicense.Id = Guid.Empty;
        }
        public VehicleLicenseEditViewmodel(VehicleLicense vehicleLicense)
        {
            _vehicleLicense = new VehicleLicense()
            {
                Id = vehicleLicense.Id,
                EndDate = vehicleLicense.EndDate,
                MotorNumber = vehicleLicense.MotorNumber,
                PlateNumber = vehicleLicense.MotorNumber,
                StartDate = vehicleLicense.StartDate,
                TrafficDepartmentName = vehicleLicense.TrafficDepartmentName,
                RowVersion = vehicleLicense.RowVersion,
                Vehicel = vehicleLicense.Vehicel,
                VehicleId = vehicleLicense.VehicleId
            };
        }
        public IValidator<VehicleLicense> Validator { get; set; }
        public Guid Id 
        {
            get => _vehicleLicense.Id; 
            private set
            {
                if (_vehicleLicense.Id != value)
                {
                    _vehicleLicense.Id = value;
                }
            }
        }
        public string MotorNumber
        {
            get => _vehicleLicense.MotorNumber;
            set
            {
                if(_vehicleLicense.MotorNumber != value)
                {
                    _vehicleLicense.MotorNumber = value;
                    OnPropertyChanged(this, nameof(MotorNumber));
                }
            }
        }
        public string PlateNumber
        {
            get => _vehicleLicense.PlateNumber;
            set
            {
                if(_vehicleLicense.PlateNumber != value)
                {
                    _vehicleLicense.PlateNumber = value;
                    OnPropertyChanged(this, nameof(_vehicleLicense.PlateNumber));
                }
            }
        }
        public DateTime StartDate
        {
            get => _vehicleLicense.StartDate;
            set
            {
                if(_vehicleLicense.StartDate != value)
                {
                    _vehicleLicense.StartDate = value;
                    OnPropertyChanged(this, nameof(StartDate));
                }
            }
        }
        public DateTime EndDate
        {
            get => _vehicleLicense.EndDate;
            set
            {
                if(_vehicleLicense.EndDate != value)
                {
                    _vehicleLicense.EndDate = value;
                    OnPropertyChanged(this, nameof(_vehicleLicense.EndDate));
                }
            }
        }
        public string TrafficDeparmentName
        {
            get => _vehicleLicense.TrafficDepartmentName;
            set
            {
                if(_vehicleLicense.TrafficDepartmentName != value)
                {
                    _vehicleLicense.TrafficDepartmentName = value;
                    OnPropertyChanged(this, nameof(TrafficDeparmentName));
                }
            }
        }
        public VehicleLicense VehicleLicense => new VehicleLicense()
        {
            Id = _vehicleLicense.Id,
            MotorNumber = _vehicleLicense.MotorNumber,
            EndDate = _vehicleLicense.EndDate,
            StartDate = _vehicleLicense.StartDate,
            PlateNumber = _vehicleLicense.PlateNumber,
            TrafficDepartmentName = _vehicleLicense.TrafficDepartmentName,
            Vehicel = _vehicleLicense.Vehicel,
            RowVersion = _vehicleLicense.RowVersion,
            VehicleId = _vehicleLicense.VehicleId
        };
        public ModelState Validate(bool notify = false)
        {
            ModelState modelState = new ModelState();
            if(Validator != null)
                modelState.AddErrors(Validator.Validate(_vehicleLicense));
            if (notify)
            {
                OnPropertyChanged(this, nameof(MotorNumber));
            }
            return modelState;
        }
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
    }
}
