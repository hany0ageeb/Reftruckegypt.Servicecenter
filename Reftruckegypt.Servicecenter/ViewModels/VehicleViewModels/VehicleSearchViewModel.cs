using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npoi.Mapper;
using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleViewModels
{
   
    public class VehicleSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<Vehicle> _vehicleValidator;
        private readonly IValidator<VehicleLicense> _vehicleLicenseValidator;
        private readonly IValidator<FuelCard> _fuelCardValidator;

        private bool _isDisposed = false;

        private int _selectedIndex = -1;
        private bool _isEditEnabled = false;
        private bool _isDeleteEnabled = false;

        private string _internalCode = "";
        private string _plateNumber = "";
        private string _chassisNumber = "";
        private string _motorNumber = "";
        private VehicleModel _vehicleModel;
        private VehicleCategory _vehicleCategory;
        private FuelCard _fuelCard;
        private FuelType _fuelType;
        private Location _maintenanceLocation;
        private Location _workingLocation;
        private string _workingState = "";
        private string _trafficDepartmentName = "";

        public VehicleSearchViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<Vehicle> vehicleValidator,
            IValidator<VehicleLicense> vehicleLicenseValidator,
            IValidator<FuelCard> fuelCardValidator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _vehicleValidator = vehicleValidator ?? throw new ArgumentNullException(nameof(vehicleValidator));
            _vehicleLicenseValidator = vehicleLicenseValidator ?? throw new ArgumentNullException(nameof(vehicleLicenseValidator));
            _fuelCardValidator = fuelCardValidator ?? throw new ArgumentNullException(nameof(fuelCardValidator));

            VehicleCategories.AddRange(_unitOfWork.VehicleCategoryRepository.Find(orderBy: q=>q.OrderBy(x=>x.Name)));
            VehicleCategories.Insert(0, new VehicleCategory() { Id = Guid.Empty, Name = "--ALL--" });
            _vehicleCategory = VehicleCategories[0];

            VehicleModels.AddRange(_unitOfWork.VehicleModelRepository.Find(orderBy: q => q.OrderBy(x => x.Name)));
            VehicleModels.Insert(0, new VehicleModel() { Id = Guid.Empty, Name = "--ALL--" });
            _vehicleModel = VehicleModels[0];

            FuelCards.AddRange(_unitOfWork.FuelCardRepository.Find(orderBy: q => q.OrderBy(x => x.Number)));
            // do not change Number of those two {Has No Fuel Card, --ALL--}as the find method in vehiclerepository depend on them ...
            FuelCards.Insert(0, new FuelCard() { Id = Guid.Empty, Number = "Has No Fuel Card" });
            FuelCards.Insert(0, new FuelCard() { Id = Guid.Empty, Number = "--ALL--" });
            _fuelCard = FuelCards[0];

            FuelTypes.AddRange(_unitOfWork.FuelTypeRepository.Find(orderBy: q => q.OrderBy(x => x.Name)));
            FuelTypes.Insert(0, new FuelType() { Id = Guid.Empty, Name = "--ALL--" });
            _fuelType = FuelTypes[0];

            Locations.AddRange(_unitOfWork.LocationRepository.Find(orderBy: q => q.OrderBy(x => x.Name)));
            Locations.Insert(0, new Location() { Id = Guid.Empty, Name = "--ALL--" });
            _maintenanceLocation = Locations[0];
            _workingLocation = Locations[0];


        }
        public string InternalCode
        {
            get => _internalCode;
            set
            {
                if(_internalCode != value)
                {
                    _internalCode = value;
                    OnPropertyChanged(this, nameof(InternalCode));
                }
            }
        }
        public string PlateNumber
        {
            get => _plateNumber;
            set
            {
                if (_plateNumber != value)
                {
                    _plateNumber = value;
                    OnPropertyChanged(this, nameof(PlateNumber));
                }
            }
        }
        public string ChassisNumber
        {
            get => _chassisNumber;
            set
            {
                if (_chassisNumber != value)
                {
                    _chassisNumber = value;
                    OnPropertyChanged(this, nameof(ChassisNumber));
                }
            }
        }
        public string MotorNumber
        {
            get => _motorNumber;
            set
            {
                if (_motorNumber != value)
                {
                    _motorNumber = value;
                    OnPropertyChanged(this, nameof(MotorNumber));
                }
            }
        }
        public VehicleCategory VehicleCategory
        {
            get => _vehicleCategory;
            set
            {
                if (_vehicleCategory != value)
                {
                    _vehicleCategory = value;
                    OnPropertyChanged(this, nameof(VehicleCategory));
                }
            }
        }
        
        public VehicleModel VehicleModel
        {
            get => _vehicleModel;
            set
            {
                if (_vehicleModel != value)
                {
                    _vehicleModel = value;
                    OnPropertyChanged(this, nameof(VehicleModel));
                }
            }
        }
        
        public FuelType FuelType
        {
            get => _fuelType;
            set
            {
                if (_fuelType != value)
                {
                    _fuelType = value;
                    OnPropertyChanged(this, nameof(FuelType));
                }
            }
        }
        
        public FuelCard FuelCard
        {
            get => _fuelCard;
            set
            {
                if (_fuelCard != value)
                {
                    _fuelCard = value;
                    OnPropertyChanged(this, nameof(FuelCard));
                }
            }
        }
        
        public Location MaintenanceLocation
        {
            get => _maintenanceLocation;
            set
            {
                if (_maintenanceLocation != value)
                {
                    _maintenanceLocation = value;
                    OnPropertyChanged(this, nameof(MaintenanceLocation));
                }
            }
        }
        
        public Location WorkingLocation
        {
            get => _workingLocation;
            set
            {
                if (_workingLocation != value)
                {
                    _workingLocation = value;
                    OnPropertyChanged(this, nameof(WorkingLocation));
                }
            }
        }
       
        
        public string WorkingState
        {
            get => _workingState;
            set
            {
                if(_workingState != value)
                {
                    _workingState = value;
                    OnPropertyChanged(this, nameof(WorkingState));
                }
            }
        }
        public string TrafficDepartment
        {
            get => _trafficDepartmentName;
            set
            {
                if (_trafficDepartmentName != value)
                {
                    _trafficDepartmentName = value;
                    OnPropertyChanged(this, nameof(TrafficDepartment));
                }
            }
        }
        public List<VehicleCategory> VehicleCategories { get; private set; } = new List<VehicleCategory>();
        public List<VehicleModel> VehicleModels { get; private set; } = new List<VehicleModel>();
        public List<FuelType> FuelTypes { get; private set; } = new List<FuelType>();
        public List<FuelCard> FuelCards { get; private set; } = new List<FuelCard>();
        public List<Location> Locations { get; private set; } = new List<Location>();
        public List<string> WorkingStates { get; private set; } = new List<string>() { "--ALL--", VehicleStates.Broken, VehicleStates.Working };
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnPropertyChanged(this, nameof(SelectedIndex));
                    IsEditEnabled = CanEditSelectedRecord();
                    IsDeleteEnabled = CanDeleteSelectedRecord();
                }
            }
        }

        public  Task<string> ImportFromExcelFileAsync(Mapper mapper, IProgress<int> progress)
        {
            return Task.Run<string>(() =>
            {
                StringBuilder sb = new StringBuilder();
                progress.Report(0);
                List<VehicleViewModel> models = mapper.Take<VehicleViewModel>().Select(r => r.Value).ToList();
                List<Vehicle> vehicles = new List<Vehicle>();
                for(int index = 0; index < models.Count; index++)
                {
                    VehicleViewModel model = models[index];
                    Vehicle vehicle = new Vehicle()
                    {
                        InternalCode = model.InternalCode,
                        ChassisNumber = model.ChassisNumber,
                        VehicleCategory = _unitOfWork.VehicleCategoryRepository.Find(x=>x.Name.Equals(model.VehicleCategoryName)).FirstOrDefault(),
                        Driver = _unitOfWork.DriverRepository.Find(x => x.Name.Equals(model.DriverName)).FirstOrDefault(),
                        FuelType = _unitOfWork.FuelTypeRepository.Find(x=>x.Name.Equals(model.FuelTypeName)).FirstOrDefault(),
                        ModelYear = model.ModelYear,
                        VehicleModel = _unitOfWork.VehicleModelRepository.Find(x => x.Name.Equals(model.ModelName)).FirstOrDefault(),
                        VehicleCode = model.VehicleCode
                    };
                    ModelState modelState = _vehicleValidator.Validate(vehicle);
                    if (modelState.HasErrors)
                    {
                        sb.AppendLine(modelState.Error);
                        continue;
                    }
                    if(!string.IsNullOrEmpty(model.FuelCardNumber) && !string.IsNullOrEmpty(model.FuelCardName) && !string.IsNullOrEmpty(model.Registration))
                    {
                        vehicle.FuelCard = new FuelCard()
                        {
                            Name = model.FuelCardName,
                            Number = model.FuelCardNumber,
                            Registration = model.Registration,
                            Vehicle = vehicle
                        };
                        modelState.AddErrors(_fuelCardValidator.Validate(vehicle.FuelCard));
                        if (modelState.HasErrors)
                        {
                            sb.AppendLine(modelState.Error);
                            continue;
                        }
                    }
                    if(!string.IsNullOrEmpty(model.PlateNumber) && !string.IsNullOrEmpty(model.MotorNumber) && model.StartDate.HasValue && model.EndDate.HasValue)
                    {
                        vehicle.VehicelLicenses.Add(new VehicleLicense()
                        {
                            PlateNumber = model.PlateNumber,
                            MotorNumber = model.MotorNumber,
                            StartDate = model.StartDate.Value,
                            EndDate = model.EndDate.Value
                        });
                        modelState.AddErrors(_vehicleLicenseValidator.Validate(vehicle.VehicelLicenses.First()));
                        if (modelState.HasErrors)
                        {
                            sb.AppendLine(modelState.Error);
                            continue;
                        }
                    }
                    if (!modelState.HasErrors)
                    {
                        if (_unitOfWork.VehicleRepository.Exists(x => x.InternalCode.Equals(vehicle.InternalCode)))
                        {
                            sb.AppendLine($"Duplicate Vehicle Internal Code: {vehicle.InternalCode}");
                            continue;
                        }
                        if (vehicles.Any(x => x.InternalCode.Equals(vehicle.InternalCode)))
                        {
                            sb.AppendLine($"Duplicate Vehicle Internal Code: {vehicle.InternalCode}");
                            continue;
                        }
                        vehicles.Add(vehicle);
                    }
                    progress.Report((int)((double)index / (double)models.Count * 100.0));
                }
                progress.Report(50);
                _unitOfWork.VehicleRepository.Add(vehicles);
                _unitOfWork.Complete();
                progress.Report(100);
                return sb.ToString();
            });
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
        public bool IsDeleteEnabled
        {
            get => _isDeleteEnabled;
            private set
            {
                if (_isDeleteEnabled != value)
                {
                    _isDeleteEnabled = value;
                    OnPropertyChanged(this, nameof(IsDeleteEnabled));
                }
            }
        }
        protected bool CanDeleteSelectedRecord()
        {
            if (_selectedIndex >= 0 && _selectedIndex < SearchResult.Count)
            {
                Guid id = SearchResult[_selectedIndex].Id;
                if(
                    _unitOfWork.FuelConsumptionRepository.Exists(x => x.VehicleId == id) ||
                    _unitOfWork.VehicleViolationRepository.Exists(x => x.VehicleId == id) ||
                    _unitOfWork.ExternalRepairBillRepository.Exists(x => x.VehicleId == id) ||
                    
                    _unitOfWork.SparePartsBillRepository.Exists(x => x.VehicleId == id) ||
                    _unitOfWork.VehicleKilometerReadingRepository.Exists(x => x.VehicleId == id) ||
                    _unitOfWork.VehicleStateChangeRepository.Exists(x => x.VehicleId == id)
                    )
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        protected bool CanEditSelectedRecord()
        {
            if (_selectedIndex >= 0 && _selectedIndex < SearchResult.Count)
            {
                return true;
            }
            return false;
        }

        internal void ExportToFile(string fileName)
        {
            Mapper mapper = new Mapper();
            mapper.Save(fileName, SearchResult);
        }

        public void Search()
        {
            Guid? fuelCardId = null;
            if (_fuelCard.Id != Guid.Empty || _fuelCard.Name != "Has No Fuel Card")
                fuelCardId = _fuelCard.Id;
            SearchResult.Clear();
            IEnumerable<Vehicle> vehicles = _unitOfWork
                .VehicleRepository
                .Find(
                    internalCode: _internalCode,
                    plateNumber: _plateNumber,
                    motorNumber: _motorNumber,
                    chassis: _chassisNumber,
                    workingState: _workingState == "--ALL--" ? "" : _workingState ,
                    categoryId: _vehicleCategory.Id,
                    modelId: _vehicleModel.Id,
                    fuelTypeId: _fuelType.Id,
                    workingLocationId: _workingLocation.Id,
                    maintenanceLocationId: _maintenanceLocation.Id,
                    fuelCardId: fuelCardId,
                    orderBy: q=>q.OrderBy(x=>x.InternalCode));
            foreach(var vehicle in vehicles)
            {
                SearchResult.Add(new VehicleViewModel(vehicle));
            }
        }
        public IList<Vehicle> FindAll()
        {
            return _unitOfWork.VehicleRepository.Find(q=>q.OrderBy(x=>x.InternalCode)).ToList();
        }
        public IList<VehicleViewModel> FindVehiclesWithRelatedTransactions(
            Guid? vehicleId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            List<VehicleViewModel> result = new List<VehicleViewModel>();
            if(vehicleId!=null && vehicleId != Guid.Empty)
            {
                vehicles.Add(_unitOfWork.VehicleRepository.Find(key: vehicleId.Value));
            }
            else
            {
                vehicles.AddRange(_unitOfWork.VehicleRepository.Find().ToList());
            }
            foreach(var vehicle in vehicles)
            {
                var consumptions = _unitOfWork.FuelConsumptionRepository.Find(
                    vehicleId: vehicle.Id,
                    fromDate: fromDate,
                    toDate: toDate,orderBy: q=>q.OrderByDescending(x=>x.ConsumptionDate));
                
                var externalInvoices = _unitOfWork.ExternalRepairBillRepository.Find<ExternalRepairBillViewModels.ExternalRepairBillViewModel>(
                    vehicleId: vehicle.Id,
                    fromDate: fromDate,
                    toDate: toDate,
                    selector: x=>new ExternalRepairBillViewModels.ExternalRepairBillViewModel()
                    {
                        BillDate = x.BillDate,
                        ExternalAutoRepairShopName = x.ExternalAutoRepairShop.Name,
                        Repairs = x.Repairs,
                        TotalAmount = x.TotalAmountInEGP
                    },
                    orderBy: q => q.OrderByDescending(x => x.BillDate));
                var internalRepairInvoicesLines =
                    _unitOfWork.SparePartsBillLineRepository.Find(
                        vehicleId: vehicle.Id,
                        fromDate: fromDate,
                        toDate: toDate,
                        orderBy: q=>q.OrderByDescending(x=>x.SparePartsBill.BillDate));
                var kilometerReadings = _unitOfWork.VehicleKilometerReadingRepository.Find(
                    vehicleId: vehicle?.Id, 
                    fromDate: fromDate, 
                    toDate: toDate, 
                    orderBy: q=>q.OrderByDescending(x=>x.ReadingDate));
                var violations = _unitOfWork.VehicleViolationRepository.Find(
                    vehicleId: vehicle?.Id, 
                    fromDate: fromDate, 
                    toDate: toDate, 
                    orderBy: q => q.OrderByDescending(x => x.ViolationDate));
                decimal startKilometer = fromDate.HasValue ? _unitOfWork.VehicleKilometerReadingRepository.FindVehicleKilometerReadingAtDate(vehicleId: vehicle.Id, fromDate.Value) : 0;
                decimal endKilometer = toDate.HasValue ? _unitOfWork.VehicleKilometerReadingRepository.FindVehicleKilometerReadingAtDate(vehicle.Id, toDate.Value) : kilometerReadings.FirstOrDefault()?.Reading ?? 0;
                var vehicleViewModel = new VehicleViewModel(vehicle);
                vehicleViewModel.TotalKilometers = endKilometer - startKilometer;
                vehicleViewModel.FuelConsumptions.AddRange(consumptions.Select(x => new FuelConsumptionViewModels.FuelConsumptionViewModel(x)));
                vehicleViewModel.FuelConsumptions.ForEach(x => x.ConsumptionDate = new DateTime(x.ConsumptionDate.Year, x.ConsumptionDate.Month,x.ConsumptionDate.Day));
                vehicleViewModel.ExternalRepairBills.AddRange(externalInvoices);
                vehicleViewModel.ExternalRepairBills.ForEach(x => x.BillDate = new DateTime(x.BillDate.Year, x.BillDate.Month, x.BillDate.Day));
                vehicleViewModel.SparePartsBills.AddRange(internalRepairInvoicesLines.Select(x => new SparePartsBillViewModels.SparePartsBillLineViewModel(x)));
                vehicleViewModel.KilometerReadings.AddRange(kilometerReadings.Select(x=>new VehicleKilometerReadingViewModels.VehicleKilometerReadingViewModel(x)));
                vehicleViewModel.VehicleViolations.AddRange(violations.Select(x => new VehicleViolationViewModels.VehicleViolationViewModel(x)));
                result.Add(vehicleViewModel);
            }
            return result;
        }
        public void Create()
        {
            VehicleEditViewModel editViewModel = new VehicleEditViewModel(
                _unitOfWork, 
                _applicationContext,
                _vehicleValidator, 
                _vehicleLicenseValidator, 
                _fuelCardValidator);
            _applicationContext.DisplayVehicleEditView(editViewModel);
            Search();
        }
        public void Edit()
        {
            if(_isEditEnabled && _selectedIndex >= 0 && _selectedIndex < SearchResult.Count)
            {
                Vehicle oldVehicle = _unitOfWork.VehicleRepository.FindVehicleWithFuelCard(key: SearchResult[_selectedIndex].Id);
                if (oldVehicle != null)
                {
                    VehicleEditViewModel vehicleEditViewModel =
                        new VehicleEditViewModel(
                            oldVehicle, 
                            _unitOfWork, 
                            _applicationContext, 
                            _vehicleValidator, 
                            _vehicleLicenseValidator,
                            _fuelCardValidator);
                    _applicationContext.DisplayVehicleEditView(vehicleEditViewModel);
                    Search();
                }
                else
                {
                    _ = _applicationContext.DisplayMessage(
                        title: "Error",
                        message: $"Vehicle {SearchResult[_selectedIndex].InternalCode} has been deleted and no longer exist!",
                        buttons: MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error);
                    Search();
                }
            }
        }
        public void Delete()
        {
            if(CanDeleteSelectedRecord() && _selectedIndex >=0 && _selectedIndex < SearchResult.Count)
            {
                DialogResult result = _applicationContext.DisplayMessage("Confirm Delete", $"Are You Sure You Want To Delete Vehicle {SearchResult[_selectedIndex].InternalCode}?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    Vehicle vehicle = _unitOfWork.VehicleRepository.Find(key: SearchResult[_selectedIndex].Id);
                    if (vehicle != null)
                    {
                        _unitOfWork.VehicleRepository.Remove(vehicle);
                        _unitOfWork.Complete();
                        Search();
                    }
                    else
                    {
                        Search();
                    }
                }
            }
        }
        public BindingList<VehicleViewModel> SearchResult { get; private set; } = new BindingList<VehicleViewModel>();
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = false;
            }
        }
    }
}
