using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            IValidator<VehicleLicense> vehicleLicenseValidator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _vehicleValidator = vehicleValidator ?? throw new ArgumentNullException(nameof(vehicleValidator));
            _vehicleLicenseValidator = vehicleLicenseValidator ?? throw new ArgumentNullException(nameof(vehicleLicenseValidator));

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
                    _unitOfWork.FuelCardRepository.Exists(x => x.Vehicle.Id == id) ||
                    _unitOfWork.SparePartsBillRepository.Exists(x => x.VehicleId == id) ||
                    _unitOfWork.VehicleKilometerReadingRepository.Exists(x => x.VehicleId == id) ||
                    _unitOfWork.VehicleStateChangeRepository.Exists(x => x.VehicleId == id)
                    )
                {
                    return false;
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
        public void Create()
        {
            VehicleEditViewModel editViewModel = new VehicleEditViewModel(_unitOfWork, _applicationContext,_vehicleValidator, _vehicleLicenseValidator);
            _applicationContext.DisplayVehicleEditView(editViewModel);
        }
        public void Edit()
        {
            if(_isEditEnabled && _selectedIndex >= 0 && _selectedIndex < SearchResult.Count)
            {
                Vehicle oldVehicle = _unitOfWork.VehicleRepository.Find(key: SearchResult[_selectedIndex].Id);
                if (oldVehicle != null)
                {
                    VehicleEditViewModel vehicleEditViewModel =
                        new VehicleEditViewModel(
                            oldVehicle, 
                            _unitOfWork, 
                            _applicationContext, 
                            _vehicleValidator, 
                            _vehicleLicenseValidator);
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
