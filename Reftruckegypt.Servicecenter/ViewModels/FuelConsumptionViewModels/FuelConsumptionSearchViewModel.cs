using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels
{
    public class FuelConsumptionSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;

        private int _selectedIndex = -1;
        private bool _isEditEnabled = false;
        private bool _isDeleteEnabled = false;

        private bool _isDisposed = false;

        private Vehicle _vehicle;
        private DateTime? _fromDate = null;
        private DateTime? _toDate = null;
        private FuelCard _fuelCard;
        private FuelType _fuelType;
        private VehicleCategory _vehicleCategory;
        private VehicleModel _vehicleModel;
        public FuelConsumptionSearchViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;

            FuelTypes.AddRange(_unitOfWork.FuelTypeRepository.Find(orderBy: q => q.OrderBy(f => f.Name)));
            FuelTypes.Insert(0, new FuelType() { Id = Guid.Empty, Name = "--ALL--" });
            _fuelType = FuelTypes[0];
            FuelCards.AddRange(_unitOfWork.FuelCardRepository.Find(orderBy: q=>q.OrderBy(c=>c.Number)));
            FuelCards.Insert(0, new FuelCard() { Id = Guid.Empty, Number = "--ALL--" });
            _fuelCard = FuelCards[0];
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(orderBy: q => q.OrderBy(v => v.InternalCode)));
            Vehicles.Insert(0, new Vehicle() { Id = Guid.Empty, InternalCode = "--ALL--" });
            _vehicle = Vehicles[0];
            VehicleCategories.AddRange(_unitOfWork.VehicleCategoryRepository.Find(orderBy: q=>q.OrderBy(e=>e.Name)));
            VehicleCategories.Insert(0, new VehicleCategory() { Id = Guid.Empty, Name = "--ALL--" });
            _vehicleCategory = VehicleCategories[0];
            VehicleModels.AddRange(_unitOfWork.VehicleModelRepository.Find(orderBy: q => q.OrderBy(m => m.Name)));
            VehicleModels.Insert(0, new VehicleModel() { Id = Guid.Empty, Name = "--ALL--" });
            _vehicleModel = VehicleModels[0];
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    IsDeleteEnabled = CanDeleteSelectedRecord();
                    IsEditEnabled = CanEditSelectedRecord();
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
        private bool CanDeleteSelectedRecord()
        {
            if(_selectedIndex>=0 && _selectedIndex < FuelConsumptions.Count)
            {
                return FuelConsumptions[_selectedIndex].State == PeriodStates.OpenState;
            }
            return false;
        }
        private bool CanEditSelectedRecord()
        {
            if (_selectedIndex >= 0 && _selectedIndex < FuelConsumptions.Count)
            {
                return FuelConsumptions[_selectedIndex].State == PeriodStates.OpenState;
            }
            return false;
        }
        public void Search()
        {

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
        public BindingList<FuelConsumptionViewModel> FuelConsumptions { get; private set; } = new BindingList<FuelConsumptionViewModel>();
        public List<FuelType> FuelTypes { get; private set; } = new List<FuelType>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public List<FuelCard> FuelCards { get; private set; } = new List<FuelCard>();
        public List<VehicleCategory> VehicleCategories { get; private set; } = new List<VehicleCategory>();
        public List<VehicleModel> VehicleModels { get; private set; } = new List<VehicleModel>();

        public void Delete()
        {
            if(_selectedIndex>=0 && _selectedIndex < FuelConsumptions.Count)
            {
                DialogResult result = _applicationContext.DisplayMessage("Confirm Delete", $"Are You Sure You Want To Delete Fuel Consumption of Vehicle {FuelConsumptions[_selectedIndex].VehicleInternalCode}?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    FuelConsumption fuelConsumption = _unitOfWork.FuelConsumptionRepository.Find(key: FuelConsumptions[_selectedIndex].Id);
                    if (fuelConsumption != null)
                    {
                        _unitOfWork.FuelConsumptionRepository.Remove(fuelConsumption);
                        _unitOfWork.Complete();
                    }
                    else
                    {
                        _ = _applicationContext.DisplayMessage("Error", $"This Record has been deleted and no longer exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void Edit()
        {
            if(_selectedIndex >= 0 && _selectedIndex < FuelConsumptions.Count)
            {
                FuelConsumption line = _unitOfWork.FuelConsumptionRepository.Find(key: FuelConsumptions[_selectedIndex].Id);
                if (line != null)
                {
                    _applicationContext.DisplayFuelConsumptionEditView(new FuelConsumptionEditViewModel(line, _unitOfWork, _applicationContext));
                    Search();
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", "The Selected Record Has been deleted and no longer exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Search();
                }
            }
        }

        public void Create()
        {
            FuelConsumptionEditViewModel fuelConsumptionEditViewModel = new FuelConsumptionEditViewModel(_unitOfWork, _applicationContext);
            _applicationContext.DisplayFuelConsumptionEditView(fuelConsumptionEditViewModel: fuelConsumptionEditViewModel);
        }
        #region IDisposable
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }
        #endregion IDisposable
    }
}
