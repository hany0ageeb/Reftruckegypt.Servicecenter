using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleKilometerReadingViewModels
{
    public class VehicleKilometerReadingEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<VehicleKilometerReading> _validator;
        private bool _hasChanged = false;
        private DateTime _readingDate;
        public VehicleKilometerReadingEditViewModel(
            IUnitOfWork unitOfWork, 
            IApplicationContext applicationContext, 
            IValidator<VehicleKilometerReading> validator)
            : this(null, unitOfWork, applicationContext, validator)
        {
            
        }
        public VehicleKilometerReadingEditViewModel(
            VehicleKilometerReading line,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<VehicleKilometerReading> validator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            if (line!=null)
                Lines.Add(new VehicleKilometerReadingLineEditViewModel(line));
            Lines.ListChanged += OnNewLineAdded;
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(v => v.InternalCode)));
            if (line != null)
                ReadingDate = line.ReadingDate;
            else
                ReadingDate = DateTime.Now;
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
        private void OnNewLineAdded(object sender, ListChangedEventArgs evt)
        {
            if (evt.NewIndex >= 0 && evt.NewIndex < Lines.Count && evt.ListChangedType == ListChangedType.ItemAdded)
            {
                VehicleKilometerReadingLineEditViewModel newLine = Lines[evt.NewIndex];
                if (newLine != null)
                {
                    newLine.ReadingDate = _readingDate;
                    newLine.Period = _unitOfWork.PeriodRepository.FindOpenPeriod(_readingDate);
                    if (Vehicles.Count > 0)
                        newLine.Vehicle = Vehicles[0];
                }
            }
            HasChanged = true;
        }
        public DateTime ReadingDate
        {
            get
            {
                return _readingDate;
            }
            set
            {
                if (_readingDate != value)
                {
                    _readingDate = value;
                    Period period = _unitOfWork.PeriodRepository.FindOpenPeriod(_readingDate);
                    if (period == null)
                    {
                        _modelstate.AddError(nameof(ReadingDate), $"No Open Period For Date: {_readingDate}");
                    }
                    else
                    {
                        _modelstate.Clear();
                    }
                    OnPropertyChanged(this, nameof(ReadingDate));
                    foreach(var line in Lines)
                    {
                        line.Period = period;
                        line.ReadingDate = _readingDate;
                        
                    }
                    HasChanged = true;
                }
            }
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                if (!_modelstate.HasErrors)
                {
                    foreach(var line in Lines)
                    {
                        var modelState = line.Validate(true);
                        if (modelState.HasErrors)
                        {
                            return false;
                        }
                    }
                    var lines = Lines.Select(l => new VehicleKilometerReading()
                    {
                        Id = l.Id,
                        Notes = l.Notes,
                        Period = l.Period,
                        Reading = l.Reading,
                        ReadingDate = l.ReadingDate,
                        Vehicle = l.Vehicle
                    });
                    foreach(var line in lines)
                    {
                        if(line.Id == Guid.Empty)
                        {
                            line.Id = Guid.NewGuid();
                            _unitOfWork.VehicleKilometerReadingRepository.Add(line);
                        }
                        else
                        {
                            var oldLine = _unitOfWork.VehicleKilometerReadingRepository.Find(key: line.Id);
                            if (oldLine != null)
                            {
                                oldLine.Notes = line.Notes;
                                oldLine.ReadingDate = line.ReadingDate;
                                oldLine.Reading = line.Reading;
                                oldLine.Vehicle = line.Vehicle;
                                oldLine.VehicleId = line.Vehicle.Id;
                                oldLine.Period = line.Period;
                            }
                        }
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
                DialogResult result = _applicationContext.DisplayMessage("Confirm Saving", $"Do You Want To Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
        public BindingList<VehicleKilometerReadingLineEditViewModel> Lines { get; private set; } = new BindingList<VehicleKilometerReadingLineEditViewModel>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        #region IDataErrorInfo
        private ModelState _modelstate = new ModelState();
        #endregion IDataErrorInfo
        #region IDataErrorInfo
        public string this[string columnName] => _modelstate[columnName];
        public string Error => _modelstate.Error;
        #endregion IDataErrorInfo
    }
}
