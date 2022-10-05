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
    public class FuelConsumptionEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;

        private bool _hasChanged = false;

        private ModelState _modelState = new ModelState();

        private DateTime _consumptionDate;
        public FuelConsumptionEditViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;

            FuelCards.AddRange(_unitOfWork.FuelCardRepository.Find(orderBy: q => q.OrderBy(e => e.Number)));
            FuelTypes.AddRange(_unitOfWork.FuelTypeRepository.Find(orderBy: q=>q.OrderBy(x=>x.Name)));
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(orderBy: q => q.OrderBy(x => x.InternalCode)));

            ConsumptionDate = DateTime.Now;
        }
        public FuelConsumptionEditViewModel(FuelConsumption line, IUnitOfWork unitOfWork, IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;

            FuelCards.AddRange(_unitOfWork.FuelCardRepository.Find(orderBy: q => q.OrderBy(e => e.Number)));
            FuelTypes.AddRange(_unitOfWork.FuelTypeRepository.Find(orderBy: q => q.OrderBy(x => x.Name)));
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(orderBy: q => q.OrderBy(x => x.InternalCode)));

            Lines.Add(new FuelConsumptionLineEditViewModel(line));

            ConsumptionDate = line.ConsumptionDate;
        }
        public DateTime ConsumptionDate
        {
            get => _consumptionDate;
            set
            {
                if (_consumptionDate != value)
                {
                    _consumptionDate = value;
                    ValidateDate();
                    OnPropertyChanged(this, nameof(ConsumptionDate));
                }
            }
        }
        public void Validate()
        {
            ValidateDate();
            if (!_modelState.HasErrors)
            {
                foreach(var line in Lines)
                {
                    ModelState modelState = line.Validate(true);
                    if (modelState.HasErrors)
                    {
                        _modelState.AddErrors(modelState);
                        return;
                    }
                }
            }
        }
        private void ValidateDate()
        {
            Period period = _unitOfWork.PeriodRepository.FindOpenPeriod(_consumptionDate);
            if (period == null)
            {
                _modelState.AddError(nameof(ConsumptionDate), $"No Open Period For Date: {_consumptionDate}");
            }
            else
            {
                _modelState.Clear();
            }
            foreach (var line in Lines)
            {
                line.Period = period;
                line.ConsumptionDate = _consumptionDate;
            }
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
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                Validate();
                if (!_modelState.HasErrors)
                {
                    IEnumerable<FuelConsumption> lines = Lines.Select(l => l.FuelConsumption);
                    foreach(FuelConsumption line in lines)
                    {
                        if(line.Id == Guid.Empty)
                        {
                            line.Id = Guid.NewGuid();
                            _unitOfWork.FuelConsumptionRepository.Add(line);
                        }
                        else
                        {
                            FuelConsumption oldLine = _unitOfWork.FuelConsumptionRepository.Find(key: line.Id);
                            oldLine.ConsumptionDate = line.ConsumptionDate;
                            oldLine.Notes = line.Notes;
                            oldLine.FuelCard = line.FuelCard;
                            oldLine.FuelType = line.FuelType;
                            oldLine.Period = line.Period;
                            oldLine.TotalAmountInEGP = line.TotalAmountInEGP;
                            oldLine.TotalConsumedQuanityInLiteres = line.TotalConsumedQuanityInLiteres;
                            oldLine.Vehicle = line.Vehicle;
                        }
                    }
                    _ = _unitOfWork.Complete();
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
                DialogResult result = _applicationContext.DisplayMessage("Confirm Save", "Do You Want To Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
        public BindingList<FuelConsumptionLineEditViewModel> Lines { get; private set; } = new BindingList<FuelConsumptionLineEditViewModel>();
        public List<FuelCard> FuelCards { get; private set; } = new List<FuelCard>();
        public List<FuelType> FuelTypes { get; private set; } = new List<FuelType>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        #region IDataErrorInfo
        public string Error => _modelState.Error;
        public string this[string columnName] => _modelState[columnName];
        #endregion IDataErrorInfo
    }
    public class FuelConsumptionLineEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private Vehicle _vehicle;
        private FuelCard _fuelCard;
        private FuelType _fuelType;
        private decimal _quantity = 1;
        private decimal _amount = 0;
        private DateTime _consumptionDate;
        private Period _period;
        private string _notes;

        private ModelState _modelState = new ModelState();
        private IValidator<FuelConsumption> _validator = new FuelConsumptionValidator();
        public FuelConsumptionLineEditViewModel()
        {
            Id = Guid.Empty;
            _notes = "";
        }
        public FuelConsumptionLineEditViewModel(FuelConsumption fuelConsumption)
        {
            Id = fuelConsumption.Id;
            _vehicle = fuelConsumption.Vehicle;
            _fuelCard = fuelConsumption.FuelCard;
            _fuelType = fuelConsumption.FuelType;
            _amount = fuelConsumption.TotalAmountInEGP;
            _quantity = fuelConsumption.TotalConsumedQuanityInLiteres;
            _notes = FuelConsumption.Notes;
        }
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
        public decimal TotalConsumedQuantityInLiteres
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(this, nameof(TotalConsumedQuantityInLiteres));
                }
            }
        }
        public decimal TotalAmountInEGP
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(this, nameof(TotalAmountInEGP));
                }
            }
        }
        public DateTime ConsumptionDate
        {
            get => _consumptionDate;
            set
            {
                if (_consumptionDate != value)
                {
                    _consumptionDate = value;
                    OnPropertyChanged(this, nameof(ConsumptionDate));
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
        public FuelConsumption FuelConsumption => new FuelConsumption()
        {
            Id = Id,
            Vehicle = Vehicle,
            FuelCard = FuelCard,
            FuelType = FuelType,
            Notes = Notes,
            ConsumptionDate = ConsumptionDate,
            Period = Period,
            TotalAmountInEGP = TotalAmountInEGP,
            TotalConsumedQuanityInLiteres = TotalConsumedQuantityInLiteres
        };
        public ModelState Validate(bool notify = false)
        {
            ModelState modelState = _validator.Validate(FuelConsumption);
            _modelState.Clear();
            _modelState.AddErrors(modelState);
            if (notify)
            {
                OnPropertyChanged(this, nameof(Vehicle));
            }
            return modelState;
        }
        #region IDataErrorInfo
        public string Error => _modelState.Error;
        public string this[string columnName] => _modelState[columnName];
        #endregion IDataErrorInfo
    }
    public class FuelConsumptionViewModel
    {
        public FuelConsumptionViewModel(FuelConsumption fuelConsumption)
        {
            Id = fuelConsumption.Id;
            State = fuelConsumption.Period.State;
            Notes = fuelConsumption.Notes;
            ConsumptionDate = fuelConsumption.ConsumptionDate;
            FuelCardNumber = fuelConsumption.FuelCard.Number;
            FuelCardName = fuelConsumption.FuelCard.Name;
            FuelTypeName = fuelConsumption.FuelType.Name;
            QuantityInLiters = fuelConsumption.TotalConsumedQuanityInLiteres;
            AmountInEGP = fuelConsumption.TotalAmountInEGP;
        }
        public Guid Id { get; private set; }
        public string State { get; private set; }
        public string VehicleInternalCode { get; private set; }
        public string FuelCardNumber { get; private set; }
        public string FuelCardName { get; private set; }
        public DateTime ConsumptionDate { get; private set; }
        public decimal QuantityInLiters { get; private set; }
        public string FuelTypeName { get; private set; }
        public decimal AmountInEGP { get; private set; }
        public string Notes { get; private set; }
    }
}
