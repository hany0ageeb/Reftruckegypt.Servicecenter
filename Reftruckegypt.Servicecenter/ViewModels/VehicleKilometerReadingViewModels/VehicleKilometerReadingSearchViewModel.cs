﻿using Npoi.Mapper;
using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleKilometerReadingViewModels
{
    public class VehicleKilometerReadingSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _untitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<VehicleKilometerReading> _validator;

        private bool _isDeleteEnabled = false;
        private bool _isEditEnabled = false;

        private int _selectedIndex = -1;

        private DateTime? _fromDate = null;
        private DateTime? _toDate = null;
        private Vehicle _vehicle;

        private bool _isDisposed = false;
        public VehicleKilometerReadingSearchViewModel(IUnitOfWork unitOfWork,
                                                      IApplicationContext applicationContext,
                                                      IValidator<VehicleKilometerReading> validator)
        {
            _untitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _validator = validator;

            Vehicels.AddRange(_untitOfWork.VehicleRepository.Find(q=>q.OrderBy(x=>x.InternalCode)).ToList());
            Vehicels.Insert(0, new Vehicle() { Id = Guid.Empty, InternalCode = "--ALL--" });
        }
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
        public DateTime? FromDate
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
        public BindingList<VehicleKilometerReadingViewModel> VehicleKilometerReadingViewModels { get; private set; } = new BindingList<VehicleKilometerReadingViewModel>();
        public List<Vehicle> Vehicels { get; private set; } = new List<Vehicle>();
        public void Search()
        {
            VehicleKilometerReadingViewModels.Clear();
            IEnumerable<VehicleKilometerReading> readings = _untitOfWork.VehicleKilometerReadingRepository.Find(
                vehicleId: _vehicle.Id, 
                fromDate: _fromDate, 
                toDate: _toDate, 
                orderBy: q => q.OrderBy(e=>e.ReadingDate).ThenBy(e=>e.Vehicle.InternalCode));
            foreach(var reading in readings)
            {
                VehicleKilometerReadingViewModels.Add(new VehicleKilometerReadingViewModel(reading));
            }

        }
        public void Create()
        {
            VehicleKilometerReadingEditViewModel model = 
                new VehicleKilometerReadingEditViewModel(_untitOfWork, _applicationContext, _validator);
            _applicationContext.DisplayKilometerReadingEditView(model);
            Search();
        }

        internal Task<string> ImportFromExcelFile(Mapper mapper, IProgress<int> progress)
        {
            return Task.Run<string>(() =>
            {
                StringBuilder stringBuilder = new StringBuilder();
                List<VehicleKilometerReading> data = new List<VehicleKilometerReading>();
                IList<VehicleKilometerReadingViewModel> readings = mapper.Take<VehicleKilometerReadingViewModel>().Select(r => r.Value).ToList();
                progress.Report(0);
                for(int index =0; index < readings.Count; index++)
                {
                    VehicleKilometerReadingViewModel vehicleKilometerReadingViewModel = readings[index];
                    VehicleKilometerReading vehicleKilometerReading = new VehicleKilometerReading()
                    {
                        Notes = vehicleKilometerReadingViewModel.Notes,
                        ReadingDate = vehicleKilometerReadingViewModel.ReadingDate,
                        Reading = vehicleKilometerReadingViewModel.Reading
                    };
                    if (!string.IsNullOrEmpty(vehicleKilometerReadingViewModel.VehicleInternalCode))
                    {
                        Vehicle vehicle =
                            _untitOfWork.VehicleRepository.Find(x => x.InternalCode.Equals(vehicleKilometerReadingViewModel.VehicleInternalCode)).FirstOrDefault();
                        vehicleKilometerReading.Vehicle = vehicle;
                        if (vehicle != null)
                        {
                            ModelState modelState = Validate(vehicleKilometerReading);
                            if (!modelState.HasErrors)
                            {
                                data.Add(vehicleKilometerReading);
                            }
                            else
                            {
                                _ = stringBuilder.AppendLine($"Invalid Row At {index + 2}: {modelState.Error}");
                            }
                        }
                        else
                        {
                            _ = stringBuilder.AppendLine($"Invalid Internal Code: {vehicleKilometerReadingViewModel.VehicleInternalCode} At Row {index + 2}");
                        }
                    }
                    else
                    {
                        _ = stringBuilder.AppendLine($"Invalid Internal Code At Row {index + 2}");
                    }
                    progress.Report((int)((double)index / (double)readings.Count / 100.0));
                }
                progress.Report(50);
                _untitOfWork.VehicleKilometerReadingRepository.Add(data);
                _untitOfWork.Complete();
                return stringBuilder.ToString();
            });
        }

        public void Edit()
        {
            if(_selectedIndex >= 0 && _selectedIndex< VehicleKilometerReadingViewModels.Count)
            {
                VehicleKilometerReading line = _untitOfWork.VehicleKilometerReadingRepository.Find(key: VehicleKilometerReadingViewModels[0].Id);
                if (line != null)
                {
                    var model = new VehicleKilometerReadingEditViewModel(line, _untitOfWork, _applicationContext, _validator);
                    _applicationContext.DisplayKilometerReadingEditView(model);
                    Search();
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", $"No Longer Exist", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Search();
                }
            }
        }
        public void Delete()
        {
            if(_selectedIndex >=0 && _selectedIndex < VehicleKilometerReadingViewModels.Count)
            {
                DialogResult result = _applicationContext.DisplayMessage(
                    "Confirm Delete", 
                    $"Are You Sure You want to delete reading of vehicle: {VehicleKilometerReadingViewModels[_selectedIndex].VehicleInternalCode}?", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    VehicleKilometerReading vehicleKilometerReading = _untitOfWork.VehicleKilometerReadingRepository.Find(key: VehicleKilometerReadingViewModels[_selectedIndex].Id);
                    if (vehicleKilometerReading != null)
                    {
                        _untitOfWork.VehicleKilometerReadingRepository.Remove(vehicleKilometerReading);
                        _untitOfWork.Complete();
                        Search();
                    }
                    else
                    {
                        _applicationContext.DisplayMessage("Info", $"Kilometer Reading of Vehicle { VehicleKilometerReadingViewModels[_selectedIndex].VehicleInternalCode} at Date { VehicleKilometerReadingViewModels[_selectedIndex].ReadingDate} no longer exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Search();
                    }
                }
            }
        }
        public ModelState Validate(VehicleKilometerReading vehicleKilometerReading)
        {
            ModelState modelState = new ModelState();
            vehicleKilometerReading.Period = _untitOfWork.PeriodRepository.FindOpenPeriod(vehicleKilometerReading.ReadingDate);
            modelState.AddErrors(_validator.Validate(vehicleKilometerReading));
            return modelState;
        }
        public bool IsDeleteEnabled
        {
            get => _isDeleteEnabled;
            private set
            {
                if(_isDeleteEnabled != value)
                {
                    _isDeleteEnabled = value;
                    OnPropertyChanged(this, nameof(IsDeleteEnabled));
                }
            }
        }

        public void ExportToFile(string fileName)
        {
            Mapper mapper = new Mapper();
            mapper.Save(fileName, VehicleKilometerReadingViewModels);
        }

        public bool IsEditEnabled
        {
            get => _isEditEnabled;
            private set
            {
                if (_isEditEnabled != value)
                {
                    _isEditEnabled = value;
                    OnPropertyChanged(this, nameof(IsEditEnabled));
                }
            }
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if(_selectedIndex != value)
                {
                    _selectedIndex = value;
                    IsDeleteEnabled = CanDeleteSelectedReading();
                    IsEditEnabled = CanEditSelectedReading();
                }
            }
        }
        private bool CanDeleteSelectedReading()
        {
            if(_selectedIndex>=0 && _selectedIndex< VehicleKilometerReadingViewModels.Count)
            {
                return VehicleKilometerReadingViewModels[_selectedIndex].State == PeriodStates.OpenState;
            }
            return false;
        }
        private bool CanEditSelectedReading()
        {
            if (_selectedIndex >= 0 && _selectedIndex < VehicleKilometerReadingViewModels.Count)
            {
                return VehicleKilometerReadingViewModels[_selectedIndex].State == PeriodStates.OpenState;
            }
            return false;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _untitOfWork.Dispose();
                _isDisposed = true;
            }
        }
    }
}
