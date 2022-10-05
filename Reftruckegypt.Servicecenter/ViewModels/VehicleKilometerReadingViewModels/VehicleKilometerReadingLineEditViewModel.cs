using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleKilometerReadingViewModels
{
    public class VehicleKilometerReadingLineEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private Vehicle _vehicle;
        private decimal _reading = 0;
        private string _notes = "";
        private DateTime _date = DateTime.Now;
        private Period _period;

        private IValidator<VehicleKilometerReading> _validator = new VehicleKilometerReadingValidator();

        public Guid Id { get; private set; }
        public VehicleKilometerReadingLineEditViewModel()
        {
            Id = Guid.Empty;
        }
        public VehicleKilometerReadingLineEditViewModel(VehicleKilometerReading line)
        {
            Id = line.Id;

            _reading = line.Reading;
            _notes = line.Notes;
            _date = line.ReadingDate;
            _vehicle = line.Vehicle;
        }
        public Vehicle Vehicle
        {
            get => _vehicle;
            set
            {
                if (_vehicle != value)
                {
                    _vehicle = value;
                    Validate();
                    OnPropertyChanged(this, nameof(Vehicle));
                }
            }
        }
        public DateTime ReadingDate
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    Validate();
                    OnPropertyChanged(this, nameof(ReadingDate));
                }
            }
        }
        public decimal Reading
        {
            get => _reading;
            set
            {
                if (_reading != value)
                {
                    _reading = value;
                    Validate();
                    OnPropertyChanged(this, nameof(Reading));
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
        public VehicleKilometerReading VehicleKilometerReading => new VehicleKilometerReading()
        {
            Id = Id == Guid.Empty ? Guid.NewGuid() : Id,
            Notes = _notes,
            Vehicle = _vehicle,
            Reading = _reading,
            Period = _period,
            ReadingDate = _date
        };
        public ModelState Validate(bool notify = false)
        {
            _modelstate.Clear();
            var modelState = _validator.Validate(VehicleKilometerReading);
            _modelstate.AddErrors(modelState);
            if (notify)
                OnPropertyChanged(this, nameof(Vehicle));
            return modelState;
        }
        #region IDataErrorInfo
        private ModelState _modelstate = new ModelState();
        #endregion IDataErrorInfo
        #region IDataErrorInfo
        public string this[string columnName] => _modelstate[columnName];
        public string Error => _modelstate.Error;
        #endregion IDataErrorInfo
    }
}
