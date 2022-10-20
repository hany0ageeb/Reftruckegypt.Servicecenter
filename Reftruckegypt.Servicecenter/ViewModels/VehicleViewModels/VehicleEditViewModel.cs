using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleViewModels
{
    public class VehicleEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<Vehicle> _vehicleValidator;
        private readonly IValidator<VehicleLicense> _vehicleLicenseValidator;
        private readonly Vehicle _vehicle;
        private bool _hasChanged = false;
        private List<VehicleLicense> originalLicenses = new List<VehicleLicense>();

        public VehicleEditViewModel(
            IUnitOfWork unitOfWork, 
            IApplicationContext applicationContext,
            IValidator<Vehicle> vehicleValidator,
            IValidator<VehicleLicense> vehicleLicenseValidator)
            : this(null, unitOfWork, applicationContext, vehicleValidator, vehicleLicenseValidator)
        {
        }
        public VehicleEditViewModel(
            Vehicle vehicle,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<Vehicle> vehicleValidator,
            IValidator<VehicleLicense> vehicleLicenseValidator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _vehicleValidator = vehicleValidator ?? throw new ArgumentNullException(nameof(vehicleValidator));
            _vehicleLicenseValidator = vehicleLicenseValidator ?? throw new ArgumentNullException(nameof(vehicleLicenseValidator));

            VehicleCategorys.AddRange(_unitOfWork.VehicleCategoryRepository.Find(orderBy: q => q.OrderBy(x => x.Name)));
            VehicleModels.AddRange(_unitOfWork.VehicleModelRepository.Find(orderBy: q => q.OrderBy(x => x.Name)));
            Drivers.AddRange(_unitOfWork.DriverRepository.Find(x => x.IsEnabled, q => q.OrderBy(x => x.Name)));
            Drivers.Insert(0, Driver.Empty);
            FuelCards.AddRange(_unitOfWork.FuelCardRepository.Find(predicate: v=>v.Vehicle == null,orderBy: q => q.OrderBy(x => x.Name)));
            
            FuelTypes.AddRange(_unitOfWork.FuelTypeRepository.Find(orderBy: q => q.OrderBy(x => x.Name)));
            OverAllStates.AddRange(_unitOfWork.VehicleOverAllStateRepository.Find(orderBy: q => q.OrderBy(x => x.Name)));
            OverAllStates.Insert(0, VehicleOverAllState.Empty);
            Locations.AddRange(_unitOfWork.LocationRepository.Find(orderBy: q => q.OrderBy(x => x.Name)));
            Locations.Insert(0, Location.Empty);
            if (vehicle is null)
            {
                _vehicle = new Vehicle()
                {
                    Id = Guid.Empty,
                    ChassisNumber = "",
                    InternalCode = "",
                    ModelYear = DateTime.Now.Year,
                    VehicleCode = "",
                    WorkingState = VehicleStates.Working
                };
                if (Drivers.Count > 0)
                    _vehicle.Driver = Drivers[0];
                if (FuelTypes.Count > 0)
                    _vehicle.FuelType = FuelTypes[0];
                if (FuelCards.Count > 0)
                    _vehicle.FuelCard = FuelCards[0];
                if (VehicleCategorys.Count > 0)
                    _vehicle.VehicleCategory = VehicleCategorys[0];
                if (VehicleModels.Count > 0)
                    _vehicle.VehicleModel = VehicleModels[0];
                if(Locations.Count > 0)
                {
                    _vehicle.MaintenanceLocation = Locations[0];
                    _vehicle.WorkLocation = Locations[0];
                }
                WorkingStates.AddRange( new []{ VehicleStates.Working, VehicleStates.Broken });
                FuelCards.Insert(0, FuelCard.Empty);
            }
            else
            {
                if (vehicle.FuelCard != null)
                {
                    if (!FuelCards.Contains(vehicle.FuelCard))
                    {
                        FuelCards.Add(vehicle.FuelCard);
                    }
                    if(!_unitOfWork.FuelConsumptionRepository.Exists(x=>x.FuelCardId == vehicle.FuelCard.Id))
                    {
                        FuelCards.Insert(0, FuelCard.Empty);
                    }
                }
                WorkingStates.Add(vehicle.WorkingState);
                _vehicle = new Vehicle()
                {
                    Id = vehicle.Id,
                    ChassisNumber = vehicle.ChassisNumber,
                    Driver =vehicle.Driver,
                    DriverId = vehicle.DriverId,
                    FuelCard = vehicle.FuelCard,
                    FuelType = vehicle.FuelType,
                    FuelTypeId = vehicle.FuelTypeId,
                    InternalCode = vehicle.InternalCode,
                    MaintenanceLocation = vehicle.MaintenanceLocation,
                    MaintenanceLocationId = vehicle.MaintenanceLocationId,
                    ModelYear = vehicle.ModelYear,
                    OverAllState = vehicle.OverAllState,
                    OverallStateId = vehicle.OverallStateId,
                    RowVersion  =vehicle.RowVersion,
                    VehicelLicenses = vehicle.VehicelLicenses,
                    VehicleCategory = vehicle.VehicleCategory,
                    VehicleCode = vehicle.VehicleCode,
                    VehicleModel = vehicle.VehicleModel,
                    WorkingState = vehicle.WorkingState,
                    WorkLocation = vehicle.WorkLocation
                };
                foreach(var vehicleLicense in vehicle.VehicelLicenses)
                {
                    Licenses.Add(new VehicleLicenseEditViewmodel(vehicleLicense));
                }
                originalLicenses.AddRange(vehicle.VehicelLicenses);
            }
            Licenses.ListChanged += (o, e) =>
            {
                if(e.PropertyDescriptor?.Name != nameof(HasChanged) && (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged))
                    HasChanged = true;
                if(e.ListChangedType == ListChangedType.ItemAdded && e.NewIndex >=0 && e.NewIndex < Licenses.Count)
                {
                    Licenses[e.NewIndex].Validator = _vehicleLicenseValidator;
                }
            };
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
        public Guid Id { get; private set; }
        public string InternalCode
        {
            get => _vehicle.InternalCode;
            set
            {
                if(_vehicle.InternalCode != value)
                {
                    _vehicle.InternalCode = value;
                    OnPropertyChanged(this, nameof(InternalCode));
                    HasChanged = true;
                }
            }
        }
        public string ChassisNumber
        {
            get => _vehicle.ChassisNumber;
            set
            {
                if (_vehicle.ChassisNumber != value)
                {
                    _vehicle.ChassisNumber = value;
                    OnPropertyChanged(this, nameof(ChassisNumber));
                    HasChanged = true;
                }
            }
        }
        public VehicleCategory VehicleCategory
        {
            get => _vehicle.VehicleCategory;

            set
            {
                if(_vehicle.VehicleCategory != value)
                {
                    _vehicle.VehicleCategory = value;
                    OnPropertyChanged(this, nameof(VehicleCategory));
                    HasChanged = true;
                }
            }
        }
        public VehicleModel VehicleModel
        {
            get => _vehicle.VehicleModel;

            set
            {
                if(_vehicle.VehicleModel != value)
                {
                    _vehicle.VehicleModel = value;
                    OnPropertyChanged(this, nameof(VehicleModel));
                    HasChanged = true;
                }
            }
        }
        public string VehicleCode
        {
            get => _vehicle.VehicleCode;
            set
            {
                if(_vehicle.VehicleCode != value)
                {
                    _vehicle.VehicleCode = value;
                    OnPropertyChanged(this, nameof(VehicleCode));
                    HasChanged = true;
                }
            }
        }
        public FuelCard FuelCard
        {
            get => _vehicle.FuelCard;
            set
            {
                if(_vehicle.FuelCard != value)
                {
                    _vehicle.FuelCard = value;
                    OnPropertyChanged(this, nameof(FuelCard));
                    HasChanged = true;
                }
            }
        }
        public VehicleOverAllState OverAllState
        {
            get => _vehicle.OverAllState;
            set
            {
                if(_vehicle.OverAllState != value)
                {
                    _vehicle.OverAllState = value;
                    OnPropertyChanged(this, nameof(_vehicle.OverAllState));
                    HasChanged = true;
                }
            }
        }
        public string WorkingState
        {
            get => _vehicle.WorkingState;
            set
            {
                if (_vehicle.WorkingState != value)
                {
                    _vehicle.WorkingState = value;
                    OnPropertyChanged(this, nameof(WorkingState));
                    HasChanged = true;
                }
            }
        }
        public Location WorkLocation
        {
            get => _vehicle.WorkLocation;
            set
            {
                if(_vehicle.WorkLocation != value)
                {
                    _vehicle.WorkLocation = value;
                    OnPropertyChanged(this, nameof(WorkLocation));
                    HasChanged = true;
                }
            }
        }
        public FuelType FuelType
        {
            get => _vehicle.FuelType;
            set
            {
                if(_vehicle.FuelType != value)
                {
                    _vehicle.FuelType = value;
                    OnPropertyChanged(this, nameof(FuelType));
                    HasChanged = true;
                }
            }
        }
        public Location MaintenanceLocation
        {
            get => _vehicle.MaintenanceLocation;
            set
            {
                if (_vehicle.MaintenanceLocation != value)
                {
                    _vehicle.MaintenanceLocation = value;
                    OnPropertyChanged(this, nameof(MaintenanceLocation));
                    HasChanged = true;
                }
            }
        }
        public Driver Driver
        {
            get => _vehicle.Driver;
            set
            {
                if (_vehicle.Driver != value)
                {
                    _vehicle.Driver = value;
                    OnPropertyChanged(this, nameof(Driver));
                    HasChanged = true;
                }
            }
        }
        public int ModelYear
        {
            get => _vehicle.ModelYear;
            set
            {
                if(_vehicle.ModelYear != value)
                {

                    _vehicle.ModelYear = value;
                    OnPropertyChanged(this, nameof(ModelYear));
                    HasChanged = true;
                }
            }
        }
        public BindingList<VehicleLicenseEditViewmodel> Licenses { get; private set; } = new BindingList<VehicleLicenseEditViewmodel>();
        public ModelState Validate()
        {
            ModelState modelState = _vehicleValidator.Validate(Vehicle);
            if (!modelState.HasErrors)
            {
                if(_vehicle.Id == Guid.Empty)
                {
                    string internalcode = _vehicle.InternalCode;
                    if (_unitOfWork.VehicleRepository.Exists(x => x.InternalCode.Equals(internalcode, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        modelState.AddError(nameof(InternalCode), $"Duplicate Vehicle Internal Code\n Internal Code: {internalcode} already exist.");
                    }
                }
                else
                {
                    string internalcode = _vehicle.InternalCode;
                    Guid id = _vehicle.Id;
                    if (_unitOfWork.VehicleRepository.Exists(x => x.Id != id && x.InternalCode.Equals(internalcode, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        modelState.AddError(nameof(InternalCode), $"Duplicate Vehicle Internal Code\n Internal Code: {internalcode} already exist.");
                    }
                }
                if (!modelState.HasErrors)
                {
                    foreach(var lic in Licenses)
                    {
                        var licSate = lic.Validate(true);
                        if (licSate.HasErrors)
                        {
                            modelState.AddError(nameof(Licenses), $"Error on one or more line(s)");
                            return modelState;
                        }
                    }
                }
            }
            return modelState;
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                ModelState modelState = Validate();
                if (modelState.HasErrors)
                {
                    OnPropertyChanged(this, nameof(InternalCode));
                    return false;
                }
                if(_vehicle.Id == Guid.Empty)
                {
                    Vehicle vehicle = Vehicle;
                    vehicle.Id = Guid.NewGuid();
                    foreach(var lic in vehicle.VehicelLicenses)
                    {
                        lic.Id = Guid.NewGuid();
                    }
                    if (vehicle.WorkingState == VehicleStates.Broken)
                    {
                        vehicle.VehicleStateChanges.Add(new VehicleStateChange()
                        {
                            FromDate = DateTime.Now,
                            ToDate = null,
                            State = VehicleStates.Broken,
                            Notes = "Initial State On Creating Vehicle"
                        });
                    }
                    _unitOfWork.VehicleRepository.Add(vehicle);
                    _unitOfWork.Complete();
                    HasChanged = false;
                    return true;
                }
                else
                {
                    Vehicle vehicle = Vehicle;
                    var oldVehicle = _unitOfWork.VehicleRepository.Find(key: _vehicle.Id);
                    if (oldVehicle != null)
                    {
                        oldVehicle.InternalCode = _vehicle.InternalCode;
                        oldVehicle.MaintenanceLocation = vehicle.MaintenanceLocation;
                        //oldVehicle.WorkingState = _vehicle.WorkingState;
                        oldVehicle.WorkLocation = vehicle.WorkLocation;
                        oldVehicle.ChassisNumber = _vehicle.ChassisNumber;
                        oldVehicle.Driver = vehicle.Driver;
                        oldVehicle.FuelCard = vehicle.FuelCard;
                        oldVehicle.FuelType = _vehicle.FuelType;
                        oldVehicle.ModelYear = _vehicle.ModelYear;
                        oldVehicle.VehicleCategory = _vehicle.VehicleCategory;
                        oldVehicle.VehicleCode = _vehicle.VehicleCode;
                        oldVehicle.OverAllState = vehicle.OverAllState;
                        var deletedIds = originalLicenses.Where(l => !Licenses.Select(x => x.Id).Contains(l.Id)).Select(x=>x.Id).ToList();
                        foreach(var deletedId in deletedIds)
                        {
                           _unitOfWork.VehicleLicenseRepository.Remove(oldVehicle.VehicelLicenses.Where(x => x.Id == deletedId).FirstOrDefault());
                        }
                        foreach(var lic in Licenses)
                        {
                            if(lic.Id == Guid.Empty)
                            {
                                var newLic = lic.VehicleLicense;
                                newLic.Id = Guid.NewGuid();
                                newLic.Vehicel = oldVehicle;
                                oldVehicle.VehicelLicenses.Add(newLic);
                            }
                            else
                            {
                                var oldLic = oldVehicle.VehicelLicenses.Where(x => x.Id == lic.Id).FirstOrDefault();
                                if (oldLic != null)
                                {
                                    oldLic.EndDate = lic.EndDate;
                                    oldLic.StartDate = lic.StartDate;
                                    oldLic.MotorNumber = lic.MotorNumber;
                                    oldLic.PlateNumber = lic.PlateNumber;
                                    oldLic.TrafficDepartmentName = lic.TrafficDeparmentName;
                                }
                            }
                        }
                    }
                    _unitOfWork.Complete();
                    HasChanged = false;
                    return true;
                }
            }
            return true;
        }
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result = _applicationContext.DisplayMessage(
                    title: "Confirm Save",
                    message: $"Do You Want To Save Changes?",
                    buttons: MessageBoxButtons.YesNoCancel,
                    icon: MessageBoxIcon.Question);
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
        public Vehicle Vehicle
        {
            get => new Vehicle()
            {
                Id = _vehicle.Id,
                ChassisNumber = _vehicle.ChassisNumber,
                Driver = _vehicle.Driver?.Id == Guid.Empty ? null : _vehicle.Driver,
                FuelCard = _vehicle.FuelCard?.Id == Guid.Empty ? null : _vehicle.FuelCard,
                FuelType = _vehicle.FuelType,
                InternalCode = _vehicle.InternalCode,
                MaintenanceLocation = _vehicle.MaintenanceLocation?.Id == Guid.Empty ? null : _vehicle.MaintenanceLocation,
                WorkLocation = _vehicle.WorkLocation?.Id == Guid.Empty ? null : _vehicle.WorkLocation,
                ModelYear = _vehicle.ModelYear,
                OverAllState = _vehicle.OverAllState?.Id == Guid.Empty ? null : _vehicle.OverAllState,
                RowVersion = _vehicle.RowVersion,
                VehicleCategory = _vehicle.VehicleCategory,
                VehicleCode = _vehicle.VehicleCode,
                VehicleModel = _vehicle.VehicleModel,
                WorkingState = _vehicle.WorkingState,
                VehicelLicenses = Licenses.Select(x => x.VehicleLicense).ToList()
            };
        }
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
        public List<VehicleCategory> VehicleCategorys { get; private set; } = new List<VehicleCategory>();
        public List<VehicleModel> VehicleModels { get; private set; } = new List<VehicleModel>();
        public List<FuelCard> FuelCards { get; private set; } = new List<FuelCard>();
        public List<FuelType> FuelTypes { get; private set; } = new List<FuelType>();
        public List<Driver> Drivers { get; private set; } = new List<Driver>();
        public List<string> WorkingStates { get; private set; } = new List<string>();
        public List<Location> Locations { get; private set; } = new List<Location>();
        public List<VehicleOverAllState> OverAllStates { get; private set; } = new List<VehicleOverAllState>();
    }
}
